## Issues

* cannot get ssl http request to work through httpclient, it worked fine on android but then it didn't', i have coded it to ignore ssl , not sure if this will affect something
* the returned message of logging in is ackward, success is always true, the only way to tell if its a problem is if error has a value
* when you close app and go back to it, it goes to the login screen



## Features
* created a custom renderer for a NoHelpEntry to use in ios so that it doesnt capitalize and upper case things




## Todo

## 1 Login

* UI - activity indicator looks terrible, make it look better
  * make the spinner bigger and centered and the message in a better location centered in the screen




## 2 Registration
* I'm sending all the info, but im never getting back a success code', I always get 3


## 3 Browser
* toolbar at bottom of the screen? android already has a toolbar.
* The arrow should take you back to the previous screen in the browser’s history
* The house should take you to the “#/” (root bookmark so whole site is not reloaded)
* The right icon should be replaced with anything that indicates refresh and it should refresh the current screen
* how do you interact with the html on the webview

## 4 Push Notifications

* read original requirements,  no idea what you are talking about with badges
* get push notifications working for IOS. followed docs and it just doesn't work, do i need a real device that is provisioned?


## 5 Tracking
*  timer to get geolocation on an interval an send to endpoint
*  Create a service for android
*  What to create for ios

## 6 Misc
* reset functiona under android application manageer




## Todo Extras
* add xamarin insight or some error handling
* need to add a test project, how do you do unit testing?
* how do you code something natively in java/swift and use in the shared code 