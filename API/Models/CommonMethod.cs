using System.ComponentModel;
using System.Data;

namespace API.Models
{
    public static class CommonMethod
    {
        public static DataTable ConvertListToDataTable<T>(this IList<T> data) { 
        
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable dt = new DataTable();
            for(int i=0; i<props.Count; i++)
            {
                PropertyDescriptor prop= props[i];
                dt.Columns.Add(prop.Name);
            }

            object[] values = new object[props.Count];
            foreach(T item in data) 
            { 
                for(int i=0; i<values.Length;i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                dt.Rows.Add(values);

            }
            return dt;    
        
        }
    }
}
