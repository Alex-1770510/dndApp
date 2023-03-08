using first.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first.Database;
public class CharProfDatabase
{
    static SQLiteAsyncConnection Database;
    
    public static readonly AsyncLazy<CharProfDatabase> Instance = new AsyncLazy<CharProfDatabase>(async () =>
    {
        var instance = new CharProfDatabase();
        CreateTableResult result = await Database.CreateTableAsync<CharProf>();
        return instance;
    });
    
    public CharProfDatabase()
    {
        if (Database is not null)
            return;
        Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
    }

    public async Task<List<CharProf>> GetItemsAsync()
    {
        return await Database.Table<CharProf>().ToListAsync();
    }

    public Task<CharProf> GetItemAsync(int id)
    {
        return Database.Table<CharProf>().Where(i => i.ID == id).FirstOrDefaultAsync();
    }

    public Task<int> SaveItemAsync(CharProf item)
    {
        if (item.ID != 0)
            return Database.UpdateAsync(item);
        else
            return Database.InsertAsync(item);
    }

    public async Task<int> DeleteItemAsync(CharProf item)
    {
        return await Database.DeleteAsync(item);
    }


}

