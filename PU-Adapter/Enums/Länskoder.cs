using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Kentor.PU_Adapter.Enums
{
    public enum Länskoder
    {
        [Description("LÄN SAKNAS ELLER ÄR FELAKTIGT")]
        SAKNAS_ELLER_FELAKTIGT = -1,

        [Description("Stockholms län")]
        Stockholms_län = 01,
        [Description("Uppsala län")]
        Uppsala_län = 03,
        [Description("Södermanlands län")]
        Södermanlands_län = 04,
        [Description("Östergötlands län")]
        Östergötlands_län = 05,
        [Description("Jönköpings län")]
        Jönköpings_län = 06,
        [Description("Kronobergs län")]
        Kronobergs_län = 07,
        [Description("Kalmar län")]
        Kalmar_län = 08,
        [Description("Gotlands län")]
        Gotlands_län = 09,
        [Description("Blekinge län")]
        Blekinge_län = 10,
        [Description("Skåne län")]
        Skåne_län = 12,
        [Description("Hallands län")]
        Hallands_län = 13,
        [Description("Västra Götalands län")]
        Västra_Götalands_län = 14,
        [Description("Värmlands län")]
        Värmlands_län = 17,
        [Description("Örebro län")]
        Örebro_län = 18,
        [Description("Västmanlands län")]
        Västmanlands_län = 19,
        [Description("Dalarnas län")]
        Dalarnas_län = 20,
        [Description("Gävleborgs län")]
        Gävleborgs_län = 21,
        [Description("Västernorrlands län")]
        Västernorrlands_län = 22,
        [Description("Jämtlands län")]
        Jämtlands_län = 23,
        [Description("Västerbottens län")]
        Västerbottens_län = 24,
        [Description("Norrbottens län")]
        Norrbottens_län = 25,
    }
}
