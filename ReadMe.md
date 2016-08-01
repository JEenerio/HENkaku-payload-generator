HENkaku payload generator.

This utility compares two payloads returned by go.henkaku.xyz/x?...
It uses the two payloads to find offsets that are modified and determines 
which addresses are used to calculate each changed offset in the payload.
It creates two files, base_payload.bin and offset.txt. base_payload.bin is used
to create a new payload based on a set of specified addresses. offsets.txt is a 
list of all offsets in the file and the address used to calculate the value at
this offset.

Usage:

Use fiddler or a suitable proxy to sniff the calls to go.henkaku.xyz/
Look for an HTTP GET request to go.henkaku.xyz/x ex:

GET /x?a1=89d02000&a2=81b00240&a3=e0002190&a4=811c08d0&&a5=e062d200&a6=e0603470&a7=e0022cf0& HTTP/1.1

Copy the request as above into response 1 Get textbox. Save the HTTP response to a file 
and browse to this to set the Request 1 Response textbox.
Repeat for the second request.

Once these details are entered, the Create Base Payload button will be enabled. 
Click to create the base_payload.bin and offsets.txt files. You can now create a 
new payload by passing the GET request into New Reponse GET textbox and clicking
Create new payload.
