#include <IRremote.h>

IRsend irsend;

void setup() {
  Serial.begin(9600);
}

void loop() {
  if (Serial.available()) {
    String command = Serial.readStringUntil('\n');
    command.trim();
    if (command == "power") {
      irsend.sendNEC(0x20DF10EF, 32); // Example: Power button
    } else if (command == "volumeup") {
      irsend.sendNEC(0x20DF40BF, 32); // Volume Up
    } else if (command == "volumedown") {
      irsend.sendNEC(0x20DFC03F, 32); // Volume Down
    }
  }
}
