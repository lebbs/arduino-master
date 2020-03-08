#include <ThingerESP8266.h>
#include <SPI.h>
#include "DHT.h"
#include <ThingerWifi.h>

#define DHTPIN D4
#define DHTTYPE DHT11
DHT dht (DHTPIN, DHTTYPE);


#define USERNAME "Tietotekniikkaprojekti"
#define DEVICE_ID "esp8266"
#define DEVICE_CREDENTIAL "Tietotekniikkaprojekti2020"

#define SSID "OnePlus 7 Pro"
#define SSID_PASSWORD "b647d94c82d5"

//#define SSID "Savonia-guest"
//#define SSID_PASSWORD ""

ThingerESP8266 thing(USERNAME, DEVICE_ID, DEVICE_CREDENTIAL);

void setup() {

Serial.begin(9600);
  
  pinMode(LED_BUILTIN, OUTPUT);

  thing.add_wifi(SSID, SSID_PASSWORD);

thing["dht11"] >> [] (pson& out){
out["humidity"] = dht.readHumidity();
out["celsius"] = dht.readTemperature();

  };
  

  // resource output example (i.e. reading a sensor value)
  thing["millis"] >> outputValue(millis());

  // more details at http://docs.thinger.io/arduino/

  




}

void loop() {

 thing.handle();
 
  
}
