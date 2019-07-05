using System.ComponentModel;
using oligo.module.c_sharp_api_text_viewer.Views;

namespace oligo.module.c_sharp_api_text_viewer.Models
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum ApiTypes
    {
        [Description("Constant")]
        Constant,
        [Description("Declares")]
        Declares,
        [Description("Types")]
        Types
    }
}