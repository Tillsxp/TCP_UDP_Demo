MyTCPServer
Inuti MyTCPServer klassen finns metoden Start(). Metoden Start() består av en listener som tar två argument. Listener kommer börja lyssna efter ett meddelande ifrån klienten. Pågrund av detta behöver den veta efter vilken IpAddress den ska lyssna efter, samt Port den ska använda. IPAddress.Any betyder att alla ipaddresser kommer vara tillängliga att skicka meddelande. Detta innebär att alla enheter som är kopplad till samma nätverk kan skicka.

`public async Task StartAsync()

TcpListener tcpListener = new TcpListener(IPAddress.Any, Settings.TCP_PORT);
tcpListener.Start();
Console.WriteLine("TCP Server started. Waiting for connections...");

`

En While loop har skapats för att konstant kunna söka efter meddelanden. Applikationen kommer stanna på AcceptTcpClient tills den har fått en anslutningen till en klient.

`  while (true)
    TcpClient client = await tcpListener.AcceptTcpClientAsync();`

Efter servern har hittat en klient som vill skicka ett meddelande, kommer Three-way-handshake göras. Detta gör anslutningen pålitlig, säker och långsam. När Three-way-handshake har slutförts kommer datan bestå av ettor och nollor. Meddelandet av användaren ska skrivas ut som en sträng och därför översättas med ASCII format. Efter översättningen är färdig kan servern skriva ut meddelandet på applikationen. När meddelandet har skrivits ut avslutas strömmen och klienten anslutning kopplas ifrån.

`Console.WriteLine("TCP Client connected.");
NetworkStream stream = client.GetStream();
byte[] buffer = new byte[1024];
int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
Console.WriteLine("TCP Message received: " + message);
stream.Close();
client.Close();
`

#MyUdpServer MyUDPServer klassen har en Start() metod kommer Listener vara UDPClient istället. Servern lyssnare efter en anslutning från en klient som vill skicka ett meddelande. Inuti lyssnaren finns ett argument om vilken port som ska användas.

`public void Start()

UdpClient udpListener = new UdpClient(Settings.UDP_PORT);
Console.WriteLine("UDP Server started. Waiting for messages...");

`
Det är VIKTIGT att inte samma portnummer används av MyTCPServer som MyUDPServer.
Inuti while loopen anges IpAddress som ska lyssnas efter. IpAddress.Any betyder att alla enheter inom samma nätverk kommer kunna skicka en förfråga om anslutning. Ingen Three-way-handshake sker och meddelandet översätts direkt. Datan kommer bestå av ettor och nollor som kommer översättas till sträng med formatet ASCII. Efter översättningen är slutförd kommer meddelandet skrivas ut i applikationen.

`while (true)

IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, Settings.UDP_PORT);
byte[] buffer = udpListener.Receive(ref clientEndPoint);
string message = Encoding.ASCII.GetString(buffer);
Console.WriteLine("UDP Message received: " + message);

`

#MyTCPClient För att kunna skicka ett meddelande till MyTCPServer behövs en klient. Klassen MyTCPClient skapar en klient, som kommer koppla upp sig till den lokala ip addressen IPAddres.loopback.

`
public void SendTcpMessage(string message)

TcpClient tcpClient = new TcpClient();
tcpClient.Connect(IPAddress.Loopback, Settings.TCP_PORT);

`

En ström skapas som kommer vara anslutningen och den som leverar datan (meddelandet). Önskat meddelande översätts och skrivs ut i applikationen när anslutningen har gjorts. När anslutningen har gjorts och datat skickats, stängs klienten och strömmen ner.

`
NetworkStream stream = tcpClient.GetStream();

byte[] data = Encoding.ASCII.GetBytes(message);
stream.Write(data, 0, data.Length);
Console.WriteLine("TCP Message sent: " + message);

stream.Close();
tcpClient.Close();
`

#MyUDPClient

För att kunna skicka ett meddelande till MyUDPServer behövs en klient. Klassen MyUDPClient skapar en klient. Denna klienten kommer koppla upp sig till den lokala ip addressen.

`UdpClient udpClient = new UdpClient();
IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Loopback, Settings.UDP_PORT);`

Ingen ström skapas och datat skickas direkt. Efter anslutningen med klient och server har gjorts samt data har skickats, stängs av klienten.

`
Console.WriteLine("UDP Message sent:" +message);

udpClient.Close();
`

#Program.cs
Vi skapar instanser av UDP- och TCP Server samt dess klienter.

`MyTcpServer tcpServer = new MyTcpServer();
MyUdpServer udpServer = new MyUdpServer();
MyTcpClient tcpClient = new MyTcpClient();
MyUdpClient udpClient = new MyUdpClient();`

Inuti konsol kommer ett meddelande med alternativ för använder över vilka servrar samt klienter kommer köras.

`Console.WriteLine(
"1. Start TCP Server för anslutning \n" +
"2. Start UDP Server för anslutning\n" +
"3. Skicka meddelande från TCP klient\n" +
"4. Skicka meddelande från UDP klient\n" +
"5. Avsluta");`

En While-loop som kommer konstant köras medans applikationen körs.
Inuti while-loopen skapas en variabel för att läsa användarens tangenttryck för övre konsol meddelandets val.

`int opt;
 if (int.TryParse(Console.ReadLine(), out opt))`

Switch-loopen läser av användarens knapptryck och väljer rätt alternativ.
Det finns 5 alternativ inuti switch loopen och en default ifall användaren skriv in ett alternativ som inte finns i listan.
Det finns alternativ att starta udp och tcp server, starta klienter som kommer skicka ett förskriv meddelande och ett alternativ att börja om.

`
case 1:

await tcpServer.StartAsync();
Console.ReadLine();

break;
case 2:

udpServer.Start();

break;
case 3:
tcpClient.SendTcpMessage("TcpClient message received");

break;
case 4:
udpClient.SendUdpMessage("UdpClient message received");

break;
case 5:
return;
default:
Console.WriteLine("That option doesn't exist. Please try again");

break;
`

#Serverapplikationen har driftsatts med hjälp av Microsoft Azure tjänster.

- Resursgrupp: TCPUDPDemoRG
- Abonnemangstyp:
- Storlek : S1
- Webbjobb: TCP_UDP_Demo
- Plats: Centrala Sverige
