#define RLOAD 22.0
#include "MQ135.h"
#include <SPI.h>

//=============joyStick===============
int joyStickButton = 7;
int joyStick_X = A0;
int joyStick_Y = A1;
int valueX;
int valueY;
//===============MQ135================
int val;
int sensorPin = A5;
MQ135 gasSensor = MQ135(sensorPin);
//===============Ultrasonic============
int ultrTriggerPin = 10;
int ultrEchoPin = 9;
long duration;
double distance;
double distanceVal;

// the setup routine runs once when you press reset:
void setup() {
  Serial.begin(9600);
  pinMode(joyStick_X, INPUT);
  pinMode(joyStick_Y, INPUT);
  pinMode(joyStickButton, INPUT_PULLUP);

  pinMode(sensorPin, INPUT);

  pinMode(ultrTriggerPin,OUTPUT);
  pinMode(ultrEchoPin, INPUT);
}
// the loop routine runs over and over again forever:
void loop() {
  valueX = analogRead(joyStick_X);
  valueY = analogRead(joyStick_Y);
  int valueX_2 = map(valueX,0,1023,2,401);
  int valueY_2 = map(valueY,0,1023,410,812);
  //Serial.print("valueX_2:");
  Serial.println(valueX_2);
  //Serial.print("valueY_2:");
  Serial.println(valueY_2);
  //delay(1000);
  bool joyStickButtonState  = digitalRead(joyStickButton);
  if(joyStickButtonState == 0){

    Serial.println(1);
  }  
//=========================MQ135======================
//detect whether people breath
  val = analogRead(sensorPin);
  float ppm = gasSensor.getPPM();
 // Serial.print ("ppm");
 // Serial.println (ppm);
  if(ppm < 1.5){
    int value = 1000;
    Serial.println (value);//activate signal
    
  }
//======================Ultrasonic=======================
//detect whether there is someone close
digitalWrite(ultrTriggerPin,LOW);
delay(1000);
digitalWrite(ultrTriggerPin, HIGH);
digitalWrite(ultrTriggerPin, LOW);
duration = pulseIn(ultrEchoPin, HIGH); //Read the pulse travel time in microseconds.
distance = duration*0.034/2; //Calculate the distance - speed of sound is 0.034 cm per microsecond
//Serial.println(distance);
if(distance<100){
//Serial.print("Distance: "); //Display the distance on the serial monitor
distanceVal = distance*1000;
Serial.println(distanceVal);
}
}