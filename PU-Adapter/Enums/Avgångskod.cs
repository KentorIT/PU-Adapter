using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Kentor.PU_Adapter.Enums
{
    public enum Avgångskod
    {
        [Display(Description = "Avliden")]
        Avliden = 1,

        [Display(Description = "Utvandrad eller (för utomlänare) avregistrerad av annat skäl")]
        Utvandrad_eller__för_utomlänare__avregistrerad_av_annat_skäl = 2,

        [Display(Description = "Överförd till obefintlig-register eller (för utomlänare) avregistrerad av annat skäl")]
        Överförd_till_obefintlig_register_eller__för_utomlänare__avregistrerad_av_annat_skäl = 3,

        [Display(Description = "Tekniskt avregistrerad")]
        Tekniskt_avregistrerad = 4,

        [Display(Description = "Personnummerändrad")]
        Personnummerändrad = 5,

        [Display(Description = "Utflyttad till annat län")]
        Utflyttad_till_annat_län = 6,
    }
}
