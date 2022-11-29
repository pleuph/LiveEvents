# LiveEvents

## Initial observations

### Context
- Experiences for kids.
- Various frontends: React, Angular, Unity, Android, iOS.
- Global deployment.
- Common services: authentication, profiles, cross-experience engagement.
- Live event service needed for various frontends.
  - Unified sign-up experience.
  - Microsites (event specific?) and apps.
  - Help gain transparency for events managed by local market groups.

### Assignment
- Create a live event backend service with both admin and user functionality.
- Users should be able to view and sign up for event via various platforms.
- Admins should be able to create and maintain events and view and manage participant lists.
- Service should expose APIs adhering to REST and/or GraphQL standards.
  - Brush up on REST.
  - GraphQL is unknown to me.
- Consider global availability, privacy & legal constraints, storage of personal user information.
- Should be deployed to AWS 
  - Challenge, as it is unknown to me. 
  - Should investigate a bit up front, but don't go too deep.
- Business logic in C# (that's the way we like it).
- Frontend not required.

### Thoughts on data requirements
**Users**
- Auth and profile managed by different services.
- Children and adults - possible restrictions, parental control/consent for signing up.
- Will have a unique Id of some sort.
- Most likely has location properties.
- Most likely has contact channel (with consent): email, phone, push notifications etc.
- Could have preferences for interests - target events.

**Admins**
- Special type of user, will share many properties.
- Types of and locations for events could be restricted.
- Should only have access to minimal participant info, maybe not direct participant contact.

**Events**
- Will have public and internal properties (participant/admin APIs).
- Event dates and timespans.
- Physical locations/venues.
- Max participants.
- Announcement dates.
- Signup/cancellation timespan.
- Name.
- Description.
- Type/Category.
- Physical accessibility info?
- Free/ticket prices (market/participant specific).
- Campaigns, promo codes etc.
- Cancellable/refundable.
- Internal information.
  - Event coordinator and other admin roles.
  - Third parties (venues, vendors, entertainment etc.).  
  - Economy (catering, giveaways, event requirements etc.).
- Translations.
- Platform availability.
- Draft/publish status.
- Edit history.
- Notification texts for event updates.
  - Announcement.
  - Signup receipt/rejection.
  - Participant cancellation receipt.
  - Event cancellation notification.
  - Signup period started/ended.
  - Various other reminders, practical info etc.

**Participants**
- Signup platform and communication channel
- Signup consent/approval based on user age/type - only present users with events they are able to sign up for.
- Can sign up to events and possibly cancel participation.
- Multiple people?
  - Number of participants.
  - Age or child/adult participant type (special needs?).
  - Partial participation?
- Tickets
- Previous events (pictures/memories?)

### Thoughts on implementation

**Scalability**
- Expected number of users?
- Expected number of events?
- Expected number of notifiations per user per event?
- Possible peak loads/zones?

**Storage**
- Some type of data storage is required.
- Depending on scalability needs:
  - Relational Db.
  - NoSql.
  - Event store.
  - File based / blob storage.
- Information security is important.
- Geographical location or replication of data could be factors important for both security, legal and performance perspectives.

**Services**
- Event admin API.
- Event participant API.
- Notification service.
- Ticket service?
- Could be APIs with many endpoints.
- Could be serverless/microservices with few endpoints.
- Caching, especially of the more static data.

As the solution should be hosted on AWS, some knowledge of the services and scalability options available is required to be able to make specific implementation decisions. I have no experience with AWS, but will assume that services comparable to Azure services are available. 

For data storage, I am most experienced in classic relational db design and implementation. These services would most likely have global availability and scalability needs, for which a relation db may or may not be sufficient. 
For PoC/demo purposes I will use a simple MSSQL database and the EF Core ORM.

The API services would most likely benefit from the scalability of a serverless architecture. How many individual services to create will depend on how much functionality is considered basic vs. additional or optional and some platforms/consumers may only need a limited set of features.
I have very limited experience with serverless APIs so for PoC/demo purposes I will try to illustrate separation of concerns in a classic .Net API.
I will assume authentication is handled by other services. I will brush up on REST and GraphQL if I have time.

## Demo

### Implemented
- Two .Net APIs.
  - Admin.
  - Participant.
- Common logic libraries, with some spearation of functionality.
  - Service lib.
  - Data lib.
- Storage is MSSQL with EF Core.
  - Model as code.
  - Deployed via migrations.
- Models mapped with AutoMapper.

### Limitations
- No error handling.
- No logging.
- No tests.
- No caching.
- No authentication.
- Not properly configurable.
- No indices in db except for PKs.
- Very limited data model.
- Probably not proper REST.
- Suitability for serverless deployment unknown.

## Solution recommendations

**Storage**
An SQL or similar relational database will probably be sufficient for most of the admin functionality. Depending on developer knowledge, building and maintaining a relational database and data model is a tried and tested approach with great tooling support. Some databases, like Azure SQL also offer great scaling and automatic performance improvements based on actual usage. I would suspect that most of the publicly available information about events will be quite static and easy to cache and/or geo-replicate. A lot of information requests would probably also be initiated by notifications, meaning some of the peak loads can be balanced by staggering notifications.

For the participant side the information is both general and personal, making parts of it harder to cache. There may also be more unexpected peak loads to handle. Some tailored redundancy in the form of a NoSql or document based storage could possibly help mitigate that. There may also be legal and security considerations in terms of the physical storage location.

For most types of data I would assume that a high degree of edit history is desirable for support and accountability purposes. This could speak to the feasibility of some type of event store, which can be based on native cloud services or other types of storage. 

A solution based on SQL + some additional, more specific purpose storage could be effective. 

**Services**
With global usage and scalability in mind, I believe serverless services with very few purposes each could be a good approach. I foresee the need for a few core services to cover the basic functionality for both admins and participants, and then a host of other services for tickets, campaigns, internal notes etc. At least one scheduled job is required for sending out notifications, possibly one for each channel (email, push etc.).

I would assume that existing authentication and profile services will be able to handle authentication. Ther may already be an existing API management or gateway system to handle auth as well as some or all of the caching requirements for API responses.