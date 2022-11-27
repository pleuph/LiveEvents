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
- Accessibility?
- Free/ticket prices (market/participant specific).
- Cancellable/refundable.
- Internal information.
  - Event coordinator and other admin roles.
  - Third parties (venues, vendors, entertainment etc.).  
  - Economy (catering, giveaways, event requirements etc.).
- Translations (probably skip this for PoC).
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