using System.ComponentModel.DataAnnotations;

namespace ApiMobile.Models
{
    public class TimeOnlyAttribute : DataTypeAttribute
    {
        public TimeOnlyAttribute() : base(DataType.Time)
        {
            DisplayFormat = new DisplayFormatAttribute { DataFormatString = "{0:HH:mm}" };
        }
    }
}