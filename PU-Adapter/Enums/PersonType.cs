using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Kentor.PU_Adapter.Enums
{
    public enum PersonType
    {
        [Display(Description = "Uppgift från RSV, ordinarie personnummer")]
        Uppgift_från_RSV__ordinarie_personnummer = 1,

        [Display(Description = "Utomlänspatient, ordinarie personnummer")]
        Utomlänspatient__ordinarie_personnummer = 2,

        [Display(Description = "Reservnummer med namnuppgift")]
        Reservnummer_med_namnuppgift = 3,

        [Display(Description = "Reservnummer utan namnuppgift")]
        Reservnummer_utan_namnuppgift = 4,

        [Display(Description = "Uppgift från RSV, samordningsnummer")]
        Uppgift_från_RSV__samordningsnummer = 5,

        [Display(Description = "Utomlänspatient, samordningsnummer")]
        Utomlänspatient__samordningsnummer = 6,

        [Display(Description = "Historiska personuppgifter, blandade källor")]
        Historiska_personuppgifter__blandade_källor = 7,
    }
}
