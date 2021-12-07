using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevOps_SecurityCase4.ViewModel;

namespace DevOps_SecurityCase4
{
    class ViewModelLocator
    {
        private static AddAnimeViewModel addAnimeViewModel = new AddAnimeViewModel();

        public static AddAnimeViewModel AddAnimeViewModel
        {
            get
            {
                return addAnimeViewModel;
            }
        }
    }
}
