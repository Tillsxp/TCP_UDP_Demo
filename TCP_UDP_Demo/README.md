#MyTCPServer
Inuti  *MyTCPServer* klassen finns metoden **Start()**. Metoden Start() består av en *listener* som tar två argument.
Listener kommer börja lyssna efter ett meddelande ifrån klienten. Pågrund av detta behöver den veta efter vilken IpAddress den ska lyssna efter, samt Port den ska använda.
*IPAddress.Any* betyder att alla ipaddresser kommer vara tillängliga att skicka meddelande. Detta innebär att alla enheter som är kopplad till samma nätverk kan skicka.
*Portnumret* har lagts in i en separat klass (**Settings**) inuti en variabel.
En While loop har skapats för att konstant kunna söka efter meddelanden. Applikationen kommer stanna på **AcceptTcpClient** tills den har fått en anslutningen till en klient.
Efter servern har hittat en klient som vill skicka ett meddelande, kommer *Three-way-handshake* göras. Detta gör anslutningen pålitlig, säker och långsam.
När Three-way-handshake har slutförts kommer datan bestå av ettor och nollor. Meddelandet av användaren ska skrivas ut som en sträng och därför översättas med ASCII format.
Efter översättningen är färdig kan servern skriva ut meddelandet på applikationen.
När meddelandet har skrivits ut avslutas strömmen och klienten anslutning kopplas ifrån.

#MyUdpServer
*MyUDPServer* klassen har en **Start()** metod kommer *Listener* vara *UDPClient* istället. 
Servern lyssnare efter en anslutning från en klient som vill skicka ett meddelande. 
Inuti lyssnaren finns ett argument om vilken port som ska användas. **Settings** innehåller en variabel med valt portnummer.
Det är **VIKTIGT** att inte samma portnummer används av *MyTCPServer* som *MyUDPServer*.
Inuti while loopen anges IpAddress som ska lyssnas efter. **IpAddress.Any** betyder att alla enheter inom samma nätverk kommer kunna skicka en förfråga om anslutning.
Ingen *Three-way-handshake* sker och meddelandet översätts direkt. 
Datan kommer bestå av ettor och nollor som kommer översättas till sträng med formatet ASCII.
Efter översättningen är slutförd kommer meddelandet skrivas ut i applikationen.

#MyTCPClient
För att kunna skicka ett meddelande till *MyTCPServer* behövs en klient. Klassen *MyTCPClient* skapar en klient,
som kommer koppla upp sig till den lokala ip addressen **IPAddres.loopback**.
En ström skapas som kommer vara anslutningen och den som leverar datan (meddelandet).
Önskat meddelande översätts och skrivs ut i applikationen när anslutningen har gjorts.
När anslutningen har gjorts och datat skickats, stängs klienten och strömmen ner.

#MyUDPClient

För att kunna skicka ett meddelande till *MyUDPServer* behövs en klient. Klassen *MyUDPClient* skapar en klient.
Denna klienten kommer koppla upp sig till den lokala ip addressen. Ingen ström skapas och datat skickas direkt.
Efter anslutningen med klient och server har gjorts samt data har skickats, stängs av klienten.

#Program.cs
Vi skapar instanser av UDP- och TCP Server samt dess klienter.
Inuti konsol kommer ett meddelande med alternativ för använder över vilka servrar samt klienter kommer köras.
En While-loop som kommer konstant köras medans applikationen körs.
Inuti while-loopen skapas en variabel för att läsa användarens tangenttryck för övre konsol meddelandets val.
Switch-loopen läser av användarens knapptryck och väljer rätt alternativ.
Det finns 5 alternativ inuti switch loopen och en default ifall användaren skriv in ett alternativ som inte finns i listan.
Det finns alternativ att starta udp och tcp server, starta klienter som kommer skicka ett förskriv meddelande och ett alternativ att börja om.


#Serverapplikationen har driftsatts med hjälp av Microsoft Azure tjänster.
- Resursgrupp: TCPUDPDemoRG
- Abonnemangstyp: 
- Storlek : S1
- Webbjobb: TCP_UDP_Demo
- Plats: Centrala Sverige