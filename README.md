# PU-Adapter
.NET adapter for fetching person data from PU
Fetches PU data via HTTPS and parses the most important fields of the returned data in to an PknodPlusData object.
The project also contains an PknodPlusInterpreter that provides a few higher level abstractions on top of the PknodPlusData.

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
        </Kentor.PU_Adapter.Properties.Settings>
    </applicationSettings>

##PU-Stub
For testing purposes there is a Stub service. You can either host the PU-Stub project your self or use http://pu-stub.azurewebsites.net/snod/
The stub contains a few test persons authorized as test persons by the Swedish Skatteverket.
An example is Tolvan Tolvansson [http://pu-stub.azurewebsites.net/snod/PKNODPLUS?arg=191212121212](http://pu-stub.azurewebsites.net/snod/PKNODPLUS?arg=191212121212).
The list of available test person numbers and reserve numbers can be found on [https://github.com/KentorIT/PU-Adapter/blob/master/TestData/Testpersonnummer.cs](https://github.com/KentorIT/PU-Adapter/blob/master/TestData/Testpersonnummer.cs)

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
For reference usage, see the command line project

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