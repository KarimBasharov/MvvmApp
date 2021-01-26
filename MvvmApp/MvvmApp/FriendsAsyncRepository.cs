using MvvmApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MvvmApp
{
    public class FriendsAsyncRepository
    {
        SQLiteAsyncConnection database;

        public FriendsAsyncRepository(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
        }

        public async Task CreateTable()
        {
            await database.CreateTableAsync<Friend>();
        }
        public async Task<List<Friend>> GetItemsAsync()
        {
            return await database.Table<Friend>().ToListAsync();

        }
        public async Task<Friend> GetItemAsync(int id)
        {
            return await database.GetAsync<Friend>(id);
        }
        public async Task<int> DeleteItemAsync(Friend item)
        {
            return await database.DeleteAsync(item);
        }
        public async Task<int> SaveItemAsync(Friend item)
        {
            if (item.Id != 0)
            {
                await database.UpdateAsync(item);
                return item.Id;
            }
            else
            {
                return await database.InsertAsync(item);
            }
        }
    }
}
