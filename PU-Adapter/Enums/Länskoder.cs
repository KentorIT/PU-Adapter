using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Kentor.PU_Adapter.Enums
{
    public enum Länskoder
    {
        [Display(Description = "LÄN SAKNAS ELLER ÄR FELAKTIGT")]
        SAKNAS_ELLER_FELAKTIGT = -1,

        [Display(Description = "Stockholms län")]
        Stockholms_län = 01,
        [Display(Description = "Uppsala län")]
        Uppsala_län = 03,
        [Display(Description = "Södermanlands län")]
        Södermanlands_län = 04,
        [Display(Description = "Östergötlands län")]
        Östergötlands_län = 05,
        [Display(Description = "Jönköpings län")]
        Jönköpings_län = 06,
        [Display(Description = "Kronobergs län")]
        Kronobergs_län = 07,
        [Display(Description = "Kalmar län")]
        Kalmar_län = 08,
        [Display(Description = "Gotlands län")]
        Gotlands_län = 09,
        [Display(Description = "Blekinge län")]
        Blekinge_län = 10,
        [Display(Description = "Skåne län")]
        Skåne_län = 12,
        [Display(Description = "Hallands län")]
        Hallands_län = 13,
        [Display(Description = "Västra Götalands län")]
        Västra_Götalands_län = 14,
        [Display(Description = "Värmlands län")]
        Värmlands_län = 17,
        [Display(Description = "Örebro län")]
        Örebro_län = 18,
        [Display(Description = "Västmanlands län")]
        Västmanlands_län = 19,
        [Display(Description = "Dalarnas län")]
        Dalarnas_län = 20,
        [Display(Description = "Gävleborgs län")]
        Gävleborgs_län = 21,
        [Display(Description = "Västernorrlands län")]
        Västernorrlands_län = 22,
        [Display(Description = "Jämtlands län")]
        Jämtlands_län = 23,
        [Display(Description = "Västerbottens län")]
        Västerbottens_län = 24,
        [Display(Description = "Norrbottens län")]
        Norrbottens_län = 25,
    }
}
