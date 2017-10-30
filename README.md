# PU-Adapter
.NET adapter for fetching person data from PU
Fetches PU data via HTTPS and parses the most important fields of the returned data in to an PknodPlusData object.
The project also contains a PknodPlusInterpreter that provides a few higher level abstractions on top of the PknodPlusData.

## Installation

Just install the NuGet package [Kentor.PU-Adapter](https://www.nuget.org/packages/Kentor.PU-Adapter)

##Configuration
In app settings

    <configSections>
        <sectionGroup name="applicationSettings" type="System.Configuration.ApplicationSettingsGroup, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" >
            <section name="Kentor.PU_Adapter.Properties.Settings" type="System.Configuration.ClientSettingsSection, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
            <!-- more sections-->
        </sectionGroup>
        <!-- more sections-->
    </configSections>

and

    <applicationSettings>
        <Kentor.PU_Adapter.Properties.Settings>
            <setting name="PknodUrl" serializeAs="String">
                <value>https://prod.pu.sll.se:10443/snod/</value>
            </setting>
            <setting name="UserName" serializeAs="String">
                <value>MyUserName</value>
            </setting>
            <setting name="Password" serializeAs="String">
                <value>MyPassword</value>
            </setting>
            <setting name="AllowUnsafePuProdCert" serializeAs="String">
                <value>False</value> <!-- Most likely you want to use the value True -->
            </setting>
        </Kentor.PU_Adapter.Properties.Settings>
    </applicationSettings>

and if you are using the PU test in your test environment add something like this in your test web configuration
  
    <applicationSettings>
        <Kentor.PU_Adapter.Properties.Settings xdt:Transform="Replace">
            <setting name="PknodUrl" serializeAs="String">
                <value>https://192.44.250.74:10443/snod/</value>
            </setting>
            <setting name="UserName" serializeAs="String">
                <value>MyPUTestUserName</value>
            </setting>
            <setting name="Password" serializeAs="String">
                <value>MyPUTestPassword</value>
            </setting>
            <setting name="AllowUnsafePuTestCert" serializeAs="String">
                <value>True</value>
            </setting>
        </Kentor.PU_Adapter.Properties.Settings>
    </applicationSettings>

##PU-Stub
For testing purposes there is a Stub service. You can either host the PU-Stub project your self or use http://pu-stub.azurewebsites.net/snod/
A searchable listing of the contents is available on http://pu-stub.azurewebsites.net/

The stub contains a few test persons authorized as test persons by the Swedish Skatteverket.
An example is Tolvan Tolvansson [http://pu-stub.azurewebsites.net/snod/PKNODPLUS?arg=191212121212](http://pu-stub.azurewebsites.net/snod/PKNODPLUS?arg=191212121212).
The list of available test person numbers and reserve numbers can be found on [https://github.com/KentorIT/PU-Adapter/blob/master/TestData/Testpersonnummer.cs](https://github.com/KentorIT/PU-Adapter/blob/master/TestData/Testpersonnummer.cs)
If you need a service that returns data for all person numbers, use http://pu-stub.azurewebsites.net/SnodWithFakeUnknown/ . It return the same data as http://pu-stub.azurewebsites.net/snod/ for data available in the stub, but with a fake persons for unknown persons.

To use the PU-stub, change the configuration to

    <applicationSettings>
        <Kentor.PU_Adapter.Properties.Settings>
            <setting name="PknodUrl" serializeAs="String">
                <value>pu-stub.azurewebsites.net/snod/</value>
            </setting>
            <setting name="UserName" serializeAs="String">
                <value />
            </setting>
            <setting name="Password" serializeAs="String">
                <value />
            </setting>
        </Kentor.PU_Adapter.Properties.Settings>
    </applicationSettings>


##Usage

Basic example

    string pnr = "191212121212";
    var fetcher = new PU_Adapter.PknodFetcher();
    var result = fetcher.FetchPknodPlusData(pnr);
    var rawString = result.Raw;
    Console.WriteLine(result.Field_Namn);
    Console.WriteLine(result.Field_Efternamn);
    Console.WriteLine(result.Field_Adress);
    var interpreter = new PknodPlusInterpreter(result);
    Console.WriteLine(string.Join(", ", interpreter.Förnamn));
    Console.WriteLine(interpreter.Tilltalsnamn);
    Console.WriteLine(interpreter.TilltalsnamnIndex);

The PU-Adapter can fetch from

* PKNODPLUS - Latest API, correct casing, correct åäö, longer address fields, etc.
* PKNOD - Legacy API, only UPPER CASE, ][\ instead of åäö, etc. Use only for backward compatibility reasons.
* PKNODH - Fetch historic information. Result indentical to PKNOD, but with the information for a specific historical date.

For more examples, see the PU-Adapter.CommandLine line project 

The JSON formatted PknodPlusData response for 191212121212 is

    {
      "Field_Förnamn": "Tolvan",
      "Field_Mellannamn": "",
      "Field_Efternamn": "Tolvansson",
      "Field_Folkbokföring_co_adress": "",
      "Field_Folkbokföringsutdelningsadress1": "",
      "Field_Folkbokföringsutdelningsadress2": "",
      "Field_Folkbokföringspostnummer": "",
      "Field_Folkbokföringspostort": "",
      "Field_Svarslängd": 1327,
      "Field_Returkod": 0,
      "Field_Personnummer_Reservnummer": "191212121212",
      "Field_Aktuellt_Personnummer": "191212121212",
      "Field_PersonIDTyp": 1,
      "Field_Namn": "Tolvansson, Tolvan",
      "Field_Adress": "TOLVAR STIGEN",
      "Field_Postnummer": "12345",
      "Field_Postort": "STOCKHOLM",
      "Field_Län": "01",
      "Field_Kommun": "80",
      "Field_Församling": "19",
      "Field_Avgångskod": null,
      "Field_Civilståndsdatum": null,
      "Field_SenasteRegDatum": "2008-01-16T00:00:00",
      "Field_Basområde": "1329999"
    }
