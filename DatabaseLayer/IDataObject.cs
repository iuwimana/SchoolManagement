using System;
using System.Linq;


namespace MIS
{
    public interface IDataObject
    {
        bool IsNew { get; set; }
        bool IsDirty { get; set; }
        bool IsDeleted { get; set; }
        void Save();
        void Load<T>(T ID);
    }
}
