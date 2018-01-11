## Issues

* cannot get ssl http request to work through httpclient on ios, works fine on android, i have coded it to ignore ssl errors for ios, not sure if this will affect something
* the returned message of logging in is ackward, success is always true, the only way to tell if its a problem is if error has a value




## Features
* created a custom renderer for a NoHelpEntry to use in ios so that it doesnt capitalize and upper case things




## Todo

## 1 Login
* if a login is sucessful then cache the username and tennant and show it always
* UI - activity indicator looks terrible, make it look better
  * make the spinner bigger and centered and the message in a better location centered in the screen
* make login screen look better
  * the words are being blurred by the background picture
* make the campus key and user name already be there in a label if it has been saved in properties


## 2 Registration
* verify that registration is working
Following are the responses from this call (do not show any response, just forward user
to the existing login URL with a busy screen message of “Loading VuTeur…”)
Success = 1,
LoginFailure = 2,
MissingData = 3,
CouldNotParseGeoLocation = 4,
NotOnCampus = 5,
NotAssociatedToAnyServers = 6,
NotAssociatedToAnyCampuses = 7,
NoServerConfiguredForGeo = 8,
NoMatchOnIp = 9
* If response above is “1”, cache that the user has been successfully registered and don’t
call this registration process again, otherwise keep trying to register to get all data



## 3 Browser
* toolbar at bottom of the screen?
* The arrow should take you back to the previous screen in the browser’s history
* The house should take you to the “#/” (root bookmark so whole site is not reloaded)
* The right icon should be replaced with anything that indicates refresh and it should refresh the current screen
* how do you interact with the html on the webview

## 4 Push Notifications

* read original requirements
* get push notifications working for IOS
* no idea what you are talking about with badges


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