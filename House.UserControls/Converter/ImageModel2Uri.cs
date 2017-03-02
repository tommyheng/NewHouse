using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using House.Utility;
using System.Windows.Markup;

namespace House.UserControls.Converter
{

    public class ImageModel2Uri : MarkupExtension, IValueConverter
    {
        /// <summary>
        /// Returns the value for the target property of this markup extension.
        /// </summary>
        /// <param name="serviceProvider">Object that can provide services for the markup extension.</param>
        /// <returns>Reference to the instance of this Int32IndexToNumberConverter.</returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //return System.Convert.ToInt32(value) + 1;
            var tmp = (value as List<FangChan.WPFModel.ImageModel>);
            if (tmp != null)
            {
                var v = from a in tmp.OrderBy(a => a.ImageIndex)
                        select new Uri(ConfigHelper.GetAppSetting("ApiUrl") + @"Images/" + a.ImageUrl, UriKind.Absolute);
                return v;
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

    }
}
