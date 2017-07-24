# SatyaOffice
#OneMicrosoft!

## Overview

We divided our project into four different modules: QuoteService, SatyaOfficeApp, TriggerListener, TriggerRelay

### QuoteService

This module will contain the database that stores Satya quotes.
Web App that runs on the cloud
Responds with a URL to a random quote from a Web API call
Satya-Quotes.AzureWebsites.net/api/GetQuoteURL

### SatyaOfficeApp
Web App that runs on the cloud
Queries Trigger Relay every few seconds to see if a new trigger event has happened
If a new trigger event is found, asks Quote Service for a random URL

### TriggerListener
Python App that runs on either a RaspberryPi, Ardruino, or a desktop
Processes trigger events (Button press, super sonic, cortana)
Sends trigger events to the Trigger Relay Web API
	example: Satya-Relay.AzureWebsites.net/api/NotifyTrigger


### TriggerRelay
Web App that runs on the cloud
Accepts Web API calls (example: Satya-Relay.AzureWebsites.net/api/NotifyTrigger)
Stores trigger events inside of a database (timestamped)
Responds with a list of trigger events from a Web API call
	example: Satya-Relay.AzureWebsites.net/api/GetTriggerHistory



