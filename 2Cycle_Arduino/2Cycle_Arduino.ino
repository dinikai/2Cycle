#include <EEPROM.h>

#define SPEED_PIN        A0
#define SPEED_SENS       505
#define WHEEL_PERIMETER  1.69

int turns = 0;
unsigned long prevTurn = 0, prevTime = 0;
float speedV = 0, rpm = 0;
bool flag = false, zeroSpeedFlag = false;
float distance = 0;

void setup() {
  pinMode(SPEED_PIN, INPUT);
  Serial.begin(9600);
}

void loop() {
  int speedValue = analogRead(SPEED_PIN);
  bool isMagnet = speedValue < SPEED_SENS;
  if (isMagnet && !flag) {
    if (turns > 0) {
      speedV = WHEEL_PERIMETER / ((float)(millis() - prevTurn) / 1000) * 3.6;
      float rps = 1000 / (float)(millis() - prevTurn);
      rpm = rps * 60;
    }
    distance += WHEEL_PERIMETER / 1000;

    zeroSpeedFlag = false;
    writeSerial(speedV);
    writeSerial(rpm);
    writeSerial(distance);
    flag = true;
    turns++;
    prevTurn = millis();
    delay(100);
  }
  if (!isMagnet) flag = false;

  if (millis() - prevTurn > 2000 && !zeroSpeedFlag) {
    speedV = 0;
    rpm = 0;
    writeSerial(speedV);
    writeSerial(rpm);
    writeSerial(distance);
    zeroSpeedFlag = true;
  }
}

void writeSerial(float value) {
  byte* valueBytes = (byte*)&value;
  Serial.write(valueBytes[0]);
  Serial.write(valueBytes[1]);
  Serial.write(valueBytes[2]);
  Serial.write(valueBytes[3]);
}
