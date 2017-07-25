/*
 *  Simple HTTP get webclient test
 */
 
#include <ESP8266WiFi.h>

const char* ssid     = "MSFTHACK";
const char* password = "redmond17";

const char* host = "satya-relay.azurewebsites.net";

const int buttonPin = 13; // the number of the pushbutton pin
const int ledPin = 15;  // the number of the LED pin

int reading = 0;           // the current reading from the input pin

int previous = 0;

long t = 0;
long debounce = 200;

void setup() {
  Serial.begin(115200);
  delay(100);
  
  // We start by connecting to a WiFi network
  
  Serial.println();
  Serial.println();
  Serial.print("Connecting to ");
  Serial.println(ssid);
  
  WiFi.begin(ssid, password);
  
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  
  Serial.println("");
  Serial.println("WiFi connected");  
  Serial.println("IP address: ");
  Serial.println(WiFi.localIP());

  pinMode(ledPin, OUTPUT);

  pinMode(buttonPin, INPUT);  
}
int value = 0;

void loop() {
  ++value;

  reading = digitalRead(buttonPin);

  // if the input just went from LOW and HIGH and we've waited long enough
  // to ignore any noise on the circuit, toggle the output pin and remember
  // the time
//  Serial.print("Reading: ");
//  Serial.println(reading);
//  Serial.print("Previous: ");
//  Serial.println(previous);
  if (reading == HIGH && previous == LOW && millis() - t > debounce) {
      digitalWrite(ledPin, HIGH);
      Serial.println("Button Pressed");

      Serial.print("connecting to ");
      Serial.println(host);
      
      // Use WiFiClient class to create TCP connections
      WiFiClient client;
      const int httpPort = 80;
      if (!client.connect(host, httpPort)) {
        Serial.println("connection failed");
        return;
      }
    // We now create a URI for the request
    String url = "/api/trigger/new/1";
    Serial.print("Requesting URL: ");
    Serial.println(url);
    
    // This will send the request to the server
    client.print(String("GET ") + url + " HTTP/1.1\r\n" +
                 "Host: " + host + "\r\n" +
                 "Connection: close\r\n\r\n");
    delay(500);
    
    // Read all the lines of the reply from server and print them to Serial
    while(client.available()){
      String line = client.readStringUntil('\r');
      Serial.print(line);
    }
    
    Serial.println();
    Serial.println("closing connection");
//
    t = millis();    
  } else {
    digitalWrite(ledPin, LOW);
  }

  previous = reading;
}


//void loop() {
//  // read the state of the pushbutton value:
//  buttonState = digitalRead(buttonPin);
//  // check if the pushbutton is pressed. If it is, the buttonState is HIGH:
//  if (buttonState == HIGH) {
//    // turn LED on:
//    digitalWrite(ledPin, HIGH);
//  } else {
//    // turn LED off:
//    digitalWrite(ledPin, LOW);
//  }
//}
