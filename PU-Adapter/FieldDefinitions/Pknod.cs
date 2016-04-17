using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kentor.PU_Adapter.FieldDefinitions
{
    public static class Pknod
    {
        /// <summary>
        /// Längden på svarssträngen, räknat fr.o.m. detta fält t.o.m det
        /// avslutande underlinetecknet. Längdfältet får automatiskt värdet 704.
        /// </summary>
        public static readonly FieldDefinition Svarslängd_0001 = new FieldDefinition(0001, 004);

        /// <summary>
        /// Status från anropet
        /// 0000 = Tjänsten utförd
        /// 0001 = Sökt person saknas i registren
        /// 0002 = Sökt person har skyddad identitet och är därför anonymiserad
        /// 0003 = Personen utflyttad och saknas i externt system
        /// 0019 = Tekniskt problem vid hämtning från externt system
        /// 0020 = Felaktigt format på inmatat personnummer
        /// 0101 = Felaktigt format på inmatat reservnummer
        /// 0102 = Reservnummer saknas i registren
        /// 0108 = Reservnummerserien slut
        /// 0110 = Födelsedatum felaktigt
        /// 0112 = Län felaktigt
        /// 0113 = Kommun felaktig
        /// 0114 = Församling felaktig
        /// 0115 = Felaktigt namn
        /// 0117 = Postnummer felaktigt
        /// 0127 = Kön felaktigt
        /// 0150 = Personnummer-från felaktigt
        /// 0151 = Personnummer-till felaktigt
        /// 0152 = Inga id-kopplingar finns
        /// 0153 = Personnummer-från saknas i registren
        /// 0154 = Personnummer-till saknas i registren
        /// 0155 = Otillåten koppling av två personnummer
        /// 0156 = Otillåten koppling av två personnummer via reservnummer
        /// 0157 = Tjänsten måste anropas med ett reservnummer
        /// 0158 = Ogiltigt datum
        /// 0159 = Historikinformation finns ej för angivet datum
        /// 0160 = Historikinformation finns ej för utomlänare/reservnummer
        /// 0300 = Programfel i tjänsten
        /// 0301 = Databasfel
        /// 0305 = Ogiltlig single-signon-biljett
        /// 0306 = Användaren saknar behörighet
        /// 0307 = Tekniskt fel i tjänsten
        /// 0308 = Databasfel eller samtidig uppdatering av annan användare
        /// 9999 = Tjänsten har utgått
        /// </summary>
        public static readonly FieldDefinition Returkod_0005 = new FieldDefinition(0005, 004);

        /// <summary>
        /// Personnummer från anropssträngen på formen SSÅÅMMDDNNNC
        /// eller reservnummer från anropssträngen på formen
        /// 99ÅÅÅÅNNNNNC
        /// </summary>
        public static readonly FieldDefinition Pnr_Rnr_0009 = new FieldDefinition(0009, 012);

        /// <summary>
        /// Födelsedatum
        /// </summary>
        public static readonly FieldDefinition Födelsedatum_0021 = new FieldDefinition(0021, 008);

        /// <summary>
        /// Personens aktuellaste identitet på formen SSÅÅMMDDNNNN.
        /// Kan vara annat än identiteten i anropet.
        /// </summary>
        public static readonly FieldDefinition Aktuellt_pnr_0029 = new FieldDefinition(0029, 012);

        /// <summary>
        /// Personidentitetstyp
        /// 1 = Uppgift från RSV, ordinarie personnummer
        /// 2 = Utomlänspatient, ordinarie personnummer
        /// 3 = Reservnummer med namnuppgift
        /// 4 = Reservnummer utan namnuppgift
        /// 5 = (ny kod) Uppgift från RSV, samordningsnummer
        /// 6 = (ny kod) Utomlänspatient, samordningsnummer
        /// </summary>
        public static readonly FieldDefinition PersonIDTyp_0041 = new FieldDefinition(0041, 001);

        /// <summary>
        /// Aktuellt namn = efternamn och ev. mellannamn, samtliga förnamn
        /// (tilltalsnamnet inom // om sådant finns anmält).
        /// </summary>
        public static readonly FieldDefinition Namn_0042 = new FieldDefinition(0042, 036);

        /// <summary>
        /// Aktuell gatuadress (gatuadress för särskild postadress om sådan finns
        /// anmäld, annars för folkbokföringsadressen)
        /// </summary>
        public static readonly FieldDefinition Adress_0078 = new FieldDefinition(0078, 027);

        /// <summary>
        /// Aktuellt postnummer (postnummer för särskild postadress om sådan
        /// finns anmäld, annars för folkbokföringsadressen)
        /// </summary>
        public static readonly FieldDefinition Postnummer_0105 = new FieldDefinition(0105, 005);

        /// <summary>
        /// Aktuell postadress (postadress för särskild postadress om sådan finns
        /// anmäld, annars för folkbokföringsadressen)
        /// </summary>
        public static readonly FieldDefinition Postort_0110 = new FieldDefinition(0110, 013);

        /// <summary>
        /// Blankt (funktionen har upphört)
        /// </summary>
        [Obsolete("Field has been removed from PU")]
        public static readonly FieldDefinition __deprecated__Telefon_hem__deprecated___0123 = new FieldDefinition(0123, 011);

        /// <summary>
        /// Blankt (funktionen har upphört)
        /// </summary>
        [Obsolete("Field has been removed from PU")]
        public static readonly FieldDefinition __deprecated__Telefon_arbete__deprecated___0134 = new FieldDefinition(0134, 011);

        /// <summary>
        /// A = Ogift
        /// B = Gift
        /// C = Änka eller änkling
        /// D = Skild
        /// E = Registrerad partner
        /// F = Skild partner
        /// G = Efterlevande partner
        /// 6 = Avliden person
        /// (RSV ser inte ”avliden” som ett särskilt civilstånd)
        /// </summary>
        public static readonly FieldDefinition Civilstånd_0145 = new FieldDefinition(0145, 001);

        /// <summary>
        /// Datum då civilstånd enligt ovan inträtt
        /// (dvs dödsdatum för avlidna)
        /// </summary>
        public static readonly FieldDefinition Civilståndsdatum_0146 = new FieldDefinition(0146, 008);

        /// <summary>
        /// Personnummer för sammanhörande person
        /// på formen SSÅÅMMDDNNNN
        /// </summary>
        public static readonly FieldDefinition Pnr_samhörig_0154 = new FieldDefinition(0154, 012);

        /// <summary>
        /// Nationalitet
        /// Blank = Svensk medborgare
        /// Numerisk = Årtal för svenskt medborgarskap
        /// Alfabetisk = Utländsk medborgare
        /// </summary>
        public static readonly FieldDefinition Nationalitet_0166 = new FieldDefinition(0166, 004);

        /// <summary>
        /// Årtal då person blev eller kommer att bli
        /// folkbokförd på län/kommun/församling nedan.
        /// </summary>
        public static readonly FieldDefinition Folkbokföringsår_på_fastigheten_0170 = new FieldDefinition(0170, 004);

        /// <summary>
        /// Länskod
        /// </summary>
        public static readonly FieldDefinition Län_0174 = new FieldDefinition(0174, 002);

        /// <summary>
        /// Kommunkod
        /// </summary>
        public static readonly FieldDefinition Kommun_0176 = new FieldDefinition(0176, 002);

        /// <summary>
        /// Församlingskod
        /// </summary>
        [Obsolete("Församling has been removed from PU")]
        public static readonly FieldDefinition Församling_0178 = new FieldDefinition(0178, 002);

        /// <summary>
        /// Senaste aviseringsvecka på formen SSÅÅVV
        /// </summary>
        public static readonly FieldDefinition Aviseringsvecka_0180 = new FieldDefinition(0180, 006);

        /// <summary>
        /// Avgångskod
        /// Blank = ej avregistrerad
        /// 1 = Avliden
        /// 2 = Utvandrad eller (för utomlänare) avregistrerad av annat skäl
        /// 3 = Överförd till obefintlig-register eller (för utomlänare)
        /// avregistrerad av annat skäl
        /// 4 = Tekniskt avregistrerad
        /// 5 = Personnummerändrad
        /// 6 = Utflyttad till annat län
        /// </summary>
        public static readonly FieldDefinition Avgångskod_0186 = new FieldDefinition(0186, 001);

        /// <summary>
        /// Senaste insättning i registret
        /// Blank = Ej insättning (dvs uppgift saknas?)
        /// 1 = Född
        /// 2 = Invandrad
        /// 3 = Överförd från obefintlig-register
        /// 4 = Tekniskt insatt
        /// 5 = Personnummerändrad
        /// 6 = Inflyttad från annat län
        /// </summary>
        public static readonly FieldDefinition Insättningskod_0187 = new FieldDefinition(0187, 001);

        /// <summary>
        /// Senaste datum för ändring av personuppgifterna
        /// </summary>
        public static readonly FieldDefinition Senaste_reg_datum_0188 = new FieldDefinition(0188, 008);

        /// <summary>
        /// Senaste registreringsdatum för inomlänare med personnummer. Form
        /// ÅÅÅÅMMDD.
        /// </summary>
        public static readonly FieldDefinition Senaste_reg_datum_inomlänare_med_pnr_0196 = new FieldDefinition(0196, 008);

        /// <summary>
        /// Senaste registreringsdatum för utomlänare och reservnummer. Form
        /// ÅÅÅÅMMDD.
        /// </summary>
        public static readonly FieldDefinition Senaste_reg_datum_utomlänare_och_reservnr_0204 = new FieldDefinition(0204, 008);

        /// <summary>
        /// Ansvarig enhet för personuppgifterna
        /// EXTERN om hämtade från RSV = utomlänare.
        /// </summary>
        public static readonly FieldDefinition Ansvarig_enhet_0212 = new FieldDefinition(0212, 008);

        /// <summary>
        /// Tidigare identitet 1
        /// </summary>
        public static readonly FieldDefinition Tidigare_identitet_1_0220 = new FieldDefinition(0220, 012);

        /// <summary>
        /// Tidigare identitet 2
        /// </summary>
        public static readonly FieldDefinition Tidigare_identitet_2_0232 = new FieldDefinition(0232, 012);

        /// <summary>
        /// Tidigare identitet 3
        /// </summary>
        public static readonly FieldDefinition Tidigare_identitet_3_0244 = new FieldDefinition(0244, 012);

        /// <summary>
        /// Tidigare identitet 4
        /// </summary>
        public static readonly FieldDefinition Tidigare_identitet_4_0256 = new FieldDefinition(0256, 012);

        /// <summary>
        /// Tidigare identitet 5
        /// </summary>
        public static readonly FieldDefinition Tidigare_identitet_5_0268 = new FieldDefinition(0268, 012);

        /// <summary>
        /// Blankt (funktionen har upphört)
        /// </summary>
        [Obsolete("Field has been removed from PU")]
        public static readonly FieldDefinition __deprecated__Tidigare_namn_1__deprecated___0280 = new FieldDefinition(0280, 036);

        /// <summary>
        /// Blankt (funktionen har upphört)
        /// </summary>
        [Obsolete("Field has been removed from PU")]
        public static readonly FieldDefinition __deprecated__Tidigare_namn_2__deprecated___0316 = new FieldDefinition(0316, 036);

        /// <summary>
        /// Fastighetsbeteckning
        /// </summary>
        public static readonly FieldDefinition Fastighetsbeteckning_0352 = new FieldDefinition(0352, 040);

        /// <summary>
        /// Fastighetens x-koordinat, två inledande nollor och åtta siffror för
        /// koordinaten.
        /// </summary>
        public static readonly FieldDefinition Fastighetens_x_koordinat_0392 = new FieldDefinition(0392, 010);

        /// <summary>
        /// Fastighetens y-koordinat, två inledande nollor och åtta siffror för
        /// koordinaten.
        /// </summary>
        public static readonly FieldDefinition Fastighetens_y_koordinat_0402 = new FieldDefinition(0402, 010);

        /// <summary>
        /// Betjäningsområdeskod utgående från fastighet.
        /// </summary>
        public static readonly FieldDefinition Betjäningsområde_från_fastighet_0412 = new FieldDefinition(0412, 008);

        /// <summary>
        /// Betjäningsområdeskod utgående från län/kommun/församling.
        /// </summary>
        public static readonly FieldDefinition Betjäningsområde_från_församling_0420 = new FieldDefinition(0420, 008);

        /// <summary>
        /// Beställaravdelning i första hand utgående från fastighet, i andra
        /// hand utgående från län/kommun/församling.
        /// Giltiga koder: 01-03, 91-93
        /// </summary>
        public static readonly FieldDefinition Beställaravd_från_fastighet_eller_i_andra_hand_församling_0428 = new FieldDefinition(0428, 002);

        /// <summary>
        /// Betjäningsområdeskod utgående från i första hand fastighet och i
        /// andra hand från län/kommun/församling.
        /// </summary>
        public static readonly FieldDefinition Betjäningsområde_från_fastighet_eller_i_andra_hand_församling_0430 = new FieldDefinition(0430, 008);

        /// <summary>
        /// Betjäningsområdesnamn
        /// </summary>
        public static readonly FieldDefinition Namn_betjäningsområde_0438 = new FieldDefinition(0438, 030);

        /// <summary>
        /// Inrättning
        /// </summary>
        public static readonly FieldDefinition Inrättning_0468 = new FieldDefinition(0468, 005);

        /// <summary>
        /// Klinik
        /// </summary>
        public static readonly FieldDefinition Klinik_0473 = new FieldDefinition(0473, 003);

        /// <summary>
        /// Avdelning
        /// </summary>
        public static readonly FieldDefinition Avdelning_0476 = new FieldDefinition(0476, 003);

        /// <summary>
        /// Vårdcentralsnamn
        /// </summary>
        public static readonly FieldDefinition Namn_vårdcentral_0479 = new FieldDefinition(0479, 020);

        /// <summary>
        /// Blankt
        /// </summary>
        [Obsolete("Field has been removed from PU")]
        public static readonly FieldDefinition __deprecated__Primärvårdsområde__deprecated___0499 = new FieldDefinition(0499, 030);

        /// <summary>
        /// Klartext till beställaravdelning i pos 428-429.
        /// </summary>
        public static readonly FieldDefinition Namn_beställaravdelning_0529 = new FieldDefinition(0529, 020);

        /// <summary>
        /// Områdeskod för psyksektor
        /// </summary>
        public static readonly FieldDefinition Psyksektor_0549 = new FieldDefinition(0549, 008);

        /// <summary>
        /// Psyksektornamn
        /// </summary>
        public static readonly FieldDefinition Namn_psyksektor_0557 = new FieldDefinition(0557, 030);

        /// <summary>
        /// Basområde från fastighet eller
        /// i andra hand församling
        /// </summary>
        public static readonly FieldDefinition Basområde_från_fastighet_eller_församling_0587 = new FieldDefinition(0587, 008);

        /// <summary>
        /// Blankt (funktionen har upphört)
        /// </summary>
        [Obsolete("Field has been removed from PU")]
        public static readonly FieldDefinition __deprecated__Husläkare__deprecated___0595 = new FieldDefinition(0595, 046);

        /// <summary>
        /// 7 om områdeskoderna i pos 428-594
        /// hämtats från fastigheten,
        /// 8 om uppgifterna hämtats från församlingen
        /// </summary>
        public static readonly FieldDefinition Källa_till_områdeskoder_0641 = new FieldDefinition(0641, 001);

        /// <summary>
        /// Används ej.
        /// </summary>
        [Obsolete("Not in use")]
        public static readonly FieldDefinition __deprecated__Statuskoder__deprecated___0642 = new FieldDefinition(0642, 010);

        /// <summary>
        /// Används ej.
        /// </summary>
        [Obsolete("Not in use")]
        public static readonly FieldDefinition __deprecated__SQL_koder__deprecated___0652 = new FieldDefinition(0652, 045);

        /// <summary>
        /// Reservfält
        /// </summary>
        [Obsolete("Not in use")]
        public static readonly FieldDefinition __deprecated__Reserv__deprecated___0697 = new FieldDefinition(0697, 007);

        /// <summary>
        /// Underlinetecken som markerar slut på svarsarean.
        /// </summary>
        public static readonly FieldDefinition Slutmarkering_0704 = new FieldDefinition(0704, 001);
    }
}
