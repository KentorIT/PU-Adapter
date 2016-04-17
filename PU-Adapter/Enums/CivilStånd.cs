using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kentor.PU_Adapter.Enums
{
    public enum Civilstånd
    {
        [Description("Ogift")]
        A_Ogift,

        [Description("Gift")]
        B_Gift,

        [Description("Änka eller änkling")]
        C_Änka_eller_änkling,

        [Description("Skild")]
        D_Skild,

        [Description("Registrerad partner")]
        E_Registrerad_partner,

        [Description("Skild partner")]
        F_Skild_partner,

        [Description("Efterlevande partner")]
        G_Efterlevande_partner,

        [Description("Avliden person")]
        _6_Avliden_person,
    }
}
