using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenSlateApp.Model;

namespace GreenSlateApp.DataLayer
{
    public static class Helpers
    {

        public static EntityState ConvertState(ObjectState objectState)
        {
            switch (objectState)
            {
                case ObjectState.Added:
                    return EntityState.Added;
                case ObjectState.Modified:
                    return EntityState.Modified;
                case ObjectState.Deleted:
                    return EntityState.Deleted;
                default:
                    return EntityState.Unchanged;
            }
        }

        public static void SetNewStateObject(this DbContext context)
        {
            foreach(var entry in context.ChangeTracker.Entries<IObjectWithState>())
            {
                IObjectWithState stateInfo = entry.Entity;
                entry.State = ConvertState(stateInfo.ObjectState);
            }
        }
    }
}
