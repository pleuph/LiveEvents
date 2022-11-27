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
- Service should expose APIs adhering to REST and/or GraphQL standards
- Consider global availability, privacy & legal constraints, storage of personal user information.
- Should be deployed to AWS 
  - Challenge, as it is unknown to me. 
  - Should investigate a bit up front, but don't go too deep.
- Business logic in C# (that's the way we like it)
- Frontend not required.