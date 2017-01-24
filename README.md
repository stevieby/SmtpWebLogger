# StmpWeb

SMTP logging console app / Windows service that runs on Port 5000 for Web with a STMP Server on port 25, 587.
Hacked together in an evening to just allow me to send emails to a fake SMTP monitor and log them to datastore for viewing.

Locations
* http://localhost:5000 - Bootstrap table of emails
* http://localhost:5000/emails - Json Emails
* http://localhost:5000/clear/emails - WIPES the database (It's a get as wanted quick way to delete)
* Emails.db - inside directory - contains LiteDB

TODO
* Refactoring
* Attachments handling 
* Screen to view individual messages
* Configuration improvements

Uses the following
* Topshelf - Windows service functionality in console
* Nancy - Rest api + serving up the view
* SMTPServer - great little library to act as a fake SMTP and then capture them
* LiteDB - amazing little NoSql database 
* MimeKitLite - mime parsing library
* Bootstrap - gui
