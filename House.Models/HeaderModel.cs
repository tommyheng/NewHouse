using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace House.Models
{
    public class UserInfoModel : Utility.MyNotifyClassBase
    {
        #region Image

        private object image;

        /// <summary>
        /// Image
        /// </summary>
        public object Image
        {
            get { return image; }
            set
            {
                if (Equals(image, value)) return;
                image = value;
                OnPropertyChanged("Image");
            }
        }



        #endregion

        #region Name

        private string name="汤老大";

        /// <summary>
        /// Image
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                if (Equals(name, value)) return;
                name = value;
                OnPropertyChanged("Name");
            }
        }



        #endregion


    }
}
