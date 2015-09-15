using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Kentor.PU_Adapter.Enums
{
    public enum PersonType
    {
        [Description("Uppgift från RSV, ordinarie personnummer")]
        Uppgift_från_RSV__ordinarie_personnummer = 1,

        [Description("Utomlänspatient, ordinarie personnummer")]
        Utomlänspatient__ordinarie_personnummer = 2,

        [Description("Reservnummer med namnuppgift")]
        Reservnummer_med_namnuppgift = 3,

        [Description("Reservnummer utan namnuppgift")]
        Reservnummer_utan_namnuppgift = 4,

        [Description("Uppgift från RSV, samordningsnummer")]
        Uppgift_från_RSV__samordningsnummer = 5,

        [Description("Utomlänspatient, samordningsnummer")]
        Utomlänspatient__samordningsnummer = 6,

        [Description("Historiska personuppgifter, blandade källor")]
        Historiska_personuppgifter__blandade_källor = 7,
    }
}
