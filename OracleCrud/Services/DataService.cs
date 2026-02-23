using Microsoft.EntityFrameworkCore;
using OracleCrud.Data;
using OracleCrud.Models;

namespace OracleCrud.Services;

public class DataService(IDbContextFactory<AppDbContext> dbFactory)
{
    // 1. MAKER: Save a new entry (Starts at Status 0 - Pending)
    public async Task CreateEntryAsync(ReferenceData entry, string makerUsername)
    {
        using (var context = dbFactory.CreateDbContext())
        {
            entry.CreatedBy = makerUsername;
            entry.CreatedOn = DateTime.Now;
            entry.Status = 0; // Pending

            context.ReferenceDataEntries.Add(entry);
            await context.SaveChangesAsync();
        }
    }

    // 2. VIEW: Fetch all records (For the Master List)
    public async Task<List<ReferenceData>> GetAllEntriesAsync()
    {
        using var context = dbFactory.CreateDbContext();
        return await context.ReferenceDataEntries
            .OrderByDescending(x => x.CreatedOn)
            .ToListAsync();
    }

    // 3. CHECKER: Fetch only Pending records for approval
    public async Task<List<ReferenceData>> GetPendingEntriesAsync()
    {
        using var context = dbFactory.CreateDbContext();
        return await context.ReferenceDataEntries
            .Where(x => x.Status == 0)
            .OrderBy(x => x.CreatedOn)
            .ToListAsync();
    }

    // 4. CHECKER: Update Status (Approve = 1, Reject = 2)
    public async Task UpdateStatusAsync(int id, int newStatus, string checkerUsername)
    {
        using var context = dbFactory.CreateDbContext();

        var record = await context.ReferenceDataEntries.FindAsync(id);
        if (record != null)
        {
            record.Status = newStatus;
            record.CheckerBy = checkerUsername;
            record.CheckerOn = DateTime.Now;

            await context.SaveChangesAsync();
        }
    }
}

