using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kentor.PU_Adapter.Enums
{
    public enum Civilstånd
    {
        [Display(Description = "Ogift")]
        A_Ogift,

        [Display(Description = "Gift")]
        B_Gift,

        [Display(Description = "Änka eller änkling")]
        C_Änka_eller_änkling,

        [Display(Description = "Skild")]
        D_Skild,

        [Display(Description = "Registrerad partner")]
        E_Registrerad_partner,

        [Display(Description = "Skild partner")]
        F_Skild_partner,

        [Display(Description = "Efterlevande partner")]
        G_Efterlevande_partner,

        [Display(Description = "Avliden person")]
        _6_Avliden_person,
    }
}
