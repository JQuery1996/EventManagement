# Event Management System :rocket:
___

A web-based application that allows users to create, manage, and participate in events.

## .NET Version :fire:
This project is built using .NET Core 8.
## Table of Contents

1. [Authentication Controller](#authentication-controller)
   - [Login](#login)
   - [Register](#register)
   
2. [User Controller](#user-controller)
   - [Get All Users](#get-all-users)
   - [Get User by ID](#get-user-by-id)
   - [Filter Users](#filter-users)
   - [Edit User](#edit-user)
   - [Remove User](#remove-user)

3. [Role Controller](#role-controller)
   - [Get All Roles](#get-all-roles)
   - [Assign Role to User](#assign-role-to-user)

4. [Permission Controller](#permission-controller)
   - [List All Permissions](#list-all-permissions)
   - [List Permissions for Role](#list-permissions-for-role)
   - [Add Permission to Role](#add-permission-to-role)

5. [Event Controller](#event-controller)
   - [Get All Events](#get-all-events)
   - [Get Event by ID](#get-event-by-id)
   - [Create Event](#create-event)
   - [Update Event](#update-event)
   - [Remove Event](#remove-event)
   - [Event Bookings](#event-bookings)

6. [Booking Controller](#booking-controller)
   - [Create Booking](#create-booking)
   - [Get Bookings](#get-bookings)
   - [Edit Booking](#edit-booking)
   - [Cancel Booking](#cancel-booking)

7. [License](#license)

## Authentication Controller

The `AuthenticationController` handles authentication-related endpoints.

### Endpoints

### <div id="login" style="background-color:#384967; border: 1px solid #3498db; padding: 10px; border-radius: 5px;">Login</div>
**Endpoint:** `POST /api/auth/login`

**Description:** Authenticate a user and generate an authentication token.

**Request:**
```json
{
  "UserName": "exampleUser",
  "Password": "examplePassword"
}
```

**Response:**
```json
{
  "User": {
    "Id": "userId",
    "Email": "user@example.com",
    "UserName": "exampleUser",
    "PhoneNumber": "1234567890"
  },
  "Token": "authenticationToken"
}
```
### <div id="register" style="background-color:#384967; border: 1px solid #3498db; padding: 10px; border-radius: 5px;">Register</div>
**Endpoint:** `POST /api/auth/register`

**Description: Register a new user.

**Request:**
```json
{
  "UserName": "newUser",
  "Email": "newuser@example.com",
  "Password": "newUserPassword"
}
```

**Response:**
```json
{
  "User": {
    "Id": "newUserId",
    "Email": "newuser@example.com",
    "UserName": "newUser",
    "PhoneNumber": null
  },
  "Token": "authenticationTokenForNewUser"
}
```

## User Controller

The `UserController` manages user-related operations.

### <div id="get-all-users" style="background-color:#384967; border: 1px solid #3498db; padding: 10px; border-radius: 5px;">1. Get All Users</div>

- **Endpoint:** `GET /api/user`
- **Description:** Retrieve a list of all users.
- **Permissions:**
  - [x] ViewUsers
- **Response:**
  - Status 200 OK: Returns a list of user details.
  - Status 401 Unauthorized: User is not authenticated.
  - Status 403 Forbidden: User lacks the necessary permissions.

### <div id="get-user-by-id" style="background-color:#384967; border: 1px solid #3498db; padding: 10px; border-radius: 5px;">2. Get User By Id</div>
- **Endpoint:** `GET /api/user/{id}`
- **Description:** Retrieve details for a specific user by ID.
- **Permissions:**
  - [x] ShowUser
- **Parameters:**
  - `id`: User ID
- **Response:**
  - Status 200 OK: Returns user details.
  - Status 204 No Content: User with the specified ID not found.
  - Status 401 Unauthorized: User is not authenticated.
  - Status 403 Forbidden: User lacks the necessary permissions.
  
### <div id="filter-users" style="background-color:#384967; border: 1px solid #3498db; padding: 10px; border-radius: 5px;">3. Filter Users</div>

- **Endpoint:** `POST /api/user/filter`
- **Description:** Filter users based on specified criteria.
- **Permissions:**
  - [x] ViewUsers
- **Request:**
```json
{
  "UserName": "exampleUser",
  "Email": "user@example.com",
  "PhoneNumber": "1234567890"
}
 ```
- **Response:**
  - Status 200 OK: Returns a list of filtered users.
  - Status 204 No Content: No users match the specified criteria.
  - Status 401 Unauthorized: User is not authenticated.
  - Status 403 Forbidden: User lacks the necessary permissions.

### <div id="edit-user" style="background-color:#384967; border: 1px solid #3498db; padding: 10px; border-radius: 5px;">4. Edit User</div>

- **Endpoint:** `Put /api/user/{id}`
- **Description:** Edit details for a specific user by ID.
- **Permissions:**
  - [x] EditUser
- **Parameters:**
  - **`id`**: User ID.
- **Request:**
```json
{
  "UserName": "exampleUser",
  "Email": "user@example.com",
  "PhoneNumber": "1234567890"
}
 ```
- **Response:**
  - Status 204 NoContent: User details successfully edited.
  - Status 401 Unauthorized: User is not authenticated.
  - Status 403 Forbidden: User lacks the necessary permissions.


### <div id="remove-user" style="background-color:#384967; border: 1px solid #3498db; padding: 10px; border-radius: 5px;">5. Remove User</div>

- **Endpoint:** `DELETE /api/user/{id}`
- **Description:** Remove a user by ID. 
- **Permissions:**
  - [x] RemoveUser
- **Parameters:**
  - **`id`**: User ID.
- **Response:**
  - Status 204 Status 204 No Content: User successfully removed.
  - Status 404 Not Found: User with the specified ID not found.
  - Status 401 Unauthorized: User is not authenticated.
  - Status 403 Forbidden: User lacks the necessary permissions.
  
## Role Controller

The `RoleController` manages role-related operations.

### <div id="get-all-roles" style="background-color:#384967; border: 1px solid #3498db; padding: 10px; border-radius: 5px;">1. Get All Roles</div>
- **Endpoint:** `GET /api/role`
- **Description:** Retrieve a list of all roles.
- **Permissions:**
  - [x] ViewRoles
- **Response:**
  - Status 200 OK: Returns a list of role details.
  - Status 401 Unauthorized: User is not authenticated.
  - Status 403 Forbidden: User lacks the necessary permissions. 
#### Example Response
```json
[
  {
    "Id": "roleId1",
    "Name": "RoleName1",
    "NormalizedName": "RoleName1Normalized"
  },
  {
    "Id": "roleId2",
    "Name": "RoleName2",
    "NormalizedName": "RoleName2Normalized"
  }
]
```
### <div id="assign-role-to-user" style="background-color:#384967; border: 1px solid #3498db; padding: 10px; border-radius: 5px;">2. Assign Role To User</div>

- **Endpoint:** `POST /api/role/assign`
- **Description:** Assign a role to the authenticated user.
- **Permissions:**
  - [x] AssignRole
- **Parameters:**
  - `role`: The role to be assigned to the user.
- **Response:**
  - Status 204 No Content: Role successfully assigned.
  - Status 401 Unauthorized: User is not authenticated.
  - Status 403 Forbidden: User lacks the necessary permissions.
  - 
## Permission Controller

The `PermissionController` manages permission-related operations.

### <div id="list-all-permissions" style="background-color:#384967; border: 1px solid #3498db; padding: 10px; border-radius: 5px;">1. List All Permissions</div>

- **Endpoint:** `GET /api/permission/Permissions`
- **Description:** Retrieve a list of all permissions.
- **Permissions:**
  - [x] ViewPermissions
- **Response:**
  - Status 200 OK: Returns a list of permission details.
  - Status 401 Unauthorized: User is not authenticated.
  - Status 403 Forbidden: User lacks the necessary permissions. 

### <div id="list-permissions-for-role" style="background-color:#384967; border: 1px solid #3498db; padding: 10px; border-radius: 5px;">2. List Permissions For Role</div>

- **Endpoint:** `GET /api/permission/RolePermissions`
- **Description:** Retrieve a list of permissions assigned to a specific role.
- **Permissions:**
  - [x] AccessPermissions
- **Parameters:**
  - `role`: The role for which permissions are requested.
- **Response:**
  - Status 200 OK: Returns a list of permission details for the specified role.
  - Status 401 Unauthorized: User is not authenticated.
  - Status 403 Forbidden: User lacks the necessary permissions.
  
### <div id="add-permission-to-role" style="background-color:#384967; border: 1px solid #3498db; padding: 10px; border-radius: 5px;">3. Add Permission To Role</div>

- **Endpoint:** `POST /api/permission`
- **Description:** Assign a permission to a role.
- **Permissions:**
  - [x] CreatePermission
- **Request:**
```json
{
  "Permission": "examplePermission",
  "Role": "exampleRole"
}
```
- **Response:**
  - Status 200 OK: Permission successfully assigned to the role.
  - Status 401 Unauthorized: User is not authenticated.
  - Status 403 Forbidden: User lacks the necessary permissions.
  
## Event Controller

The `EventController` manages event-related operations.

### <div id="get-all-events" style="background-color:#384967; border: 1px solid #3498db; padding: 10px; border-radius: 5px;">1. Get All Events</div>

- **Endpoint:** `GET /api/event`
- **Description:** Retrieve a list of all available events.
- **Permissions:**
  - [x] ViewEvents
- **Response:**
  - Status 200 OK: Returns a list of event details.
  - Status 401 Unauthorized: User is not authenticated.
  - Status 403 Forbidden: User lacks the necessary permissions.

### <div id="get-event-by-id" style="background-color:#384967; border: 1px solid #3498db; padding: 10px; border-radius: 5px;">2. Get Event By Id</div>

- **Endpoint:** `GET /api/event/{id:int}`
- **Description:** Retrieve details for a specific event by ID.
- **Permissions:**
  - [x] ShowEvent
- **Parameters:**
  - `id`: Event ID
- **Response:**
  - Status 200 OK: Returns event details.
  - Status 404 Not Found: Event with the specified ID not found.
  - Status 401 Unauthorized: User is not authenticated.
  - Status 403 Forbidden: User lacks the necessary permissions.

### <div id="create-event" style="background-color:#384967; border: 1px solid #3498db; padding: 10px; border-radius: 5px;">3. Create Event</div>

- **Endpoint:** `POST /api/event`
- **Description:** Create a new event.
- **Permissions:**
  - CreateEvent
- **Request:**
```json
{
  "NameEn": "Event Name in English",
  "NameAr": "Event Name in Arabic",
  "DescriptionEn": "Event Description in English",
  "DescriptionAr": "Event Description in Arabic",
  "Location": "Event Location",
  "AvailableTickets": 100,
  "Date": "2023-12-31T23:59:59"
}
```
- **Response:**
  - Status 201 Created: Event successfully created.
  - Status 401 Unauthorized: User is not authenticated.
  - Status 403 Forbidden: User lacks the necessary permissions.

### <div id="update-event" style="background-color:#384967; border: 1px solid #3498db; padding: 10px; border-radius: 5px;">4. Update Event</div>

- **Endpoint:** `PUT /api/event/{id:int}`
- **Description:**  Update details for a specific event by ID
- **Permissions:**
  - [x] EditEvent
- **Parameters:**
  - `id`: Event ID
- **Request:**
```json
{
  "NameEn": "Updated Event Name in English",
  "NameAr": "Updated Event Name in Arabic",
  "DescriptionEn": "Updated Event Description in English",
  "DescriptionAr": "Updated Event Description in Arabic",
  "Location": "Updated Event Location",
  "AvailableTickets": 150,
  "Date": "2023-12-31T23:59:59"
}
```
- **Response:**
  - Status 200 OK: Event details successfully updated.
  - Status 401 Unauthorized: User is not authenticated.
  - Status 403 Forbidden: User lacks the necessary permissions.

### <div id="remove-event" style="background-color:#384967; border: 1px solid #3498db; padding: 10px; border-radius: 5px;">5. Remove Event</div>

- **Endpoint:** `DELETE /api/event/{id:int}`
- **Description:**  Remove a specific event by ID.
- **Permissions:**
  - [x] RemoveEvent
- **Parameters:**
  - `id`: Event ID
- **Response:**
  - Status 204 No Content: Event successfully removed.
  - Status 401 Unauthorized: User is not authenticated.
  - Status 403 Forbidden: User lacks the necessary permissions.

### <div id="event-bookings" style="background-color:#384967; border: 1px solid #3498db; padding: 10px; border-radius: 5px;">6. Event Bookings</div>

- **Endpoint:** `GET /api/event/{id:int}/bookings`
- **Description:** Retrieve all bookings associated with a specific event by ID.
- **Permissions:**
  - [x] ViewBookings
- **Parameters:**
  - `id`: Event ID.
- **Response:**
  - Status 200 OK: Returns a list of booking details for the specified event.
  - Status 401 Unauthorized: User is not authenticated.
  - Status 403 Forbidden: User lacks the necessary permissions.
## Booking Controller

The `BookingController` manages booking-related operations.

### <div id="create-booking" style="background-color:#384967; border: 1px solid #3498db; padding: 10px; border-radius: 5px;">1. Create Booking</div>

- **Endpoint:** `POST /api/booking`
- **Description:** Create a booking for a specific event.
- **Permissions:**
  - [x] CreateBooking
- **Request:**
```json
{
  "EventId": 1,
  "NumberOfTickets": 2
}
```
- **Response:**
  - Status 200 OK: Booking successfully created.
  - Status 401 Unauthorized: User is not authenticated.

### <div id="get-bookings" style="background-color:#384967; border: 1px solid #3498db; padding: 10px; border-radius: 5px;">1. Get Bookings</div>

- **Endpoint:** `GET /api/booking`
- **Description:** Retrieve bookings for the authenticated user.
- **Permissions:**
  - [x] ViewBookings
- **Response:**
  - Status 200 OK: Returns a list of booking details.
  - Status 204 No Content: No bookings found for the user.
  - Status 401 Unauthorized: User is not authenticated.

### <div id="edit-booking" style="background-color:#384967; border: 1px solid #3498db; padding: 10px; border-radius: 5px;">3. Edit Booking</div>

- **Endpoint:** `PUT /api/booking/{id:int}`
- **Description:** Update details for a specific booking by ID. 
- **Permissions:**
  - [x] EditBooking
- **Parameters:**
  - `id`: Booking ID
- **Request:**
```json
{
  "NumberOfTickets": 3
}
```
- **Response:**
  - Status 200 OK: Booking details successfully updated.
  - Status 401 Unauthorized: User is not authenticated.
 
### <div id="cancel-booking" style="background-color:#384967; border: 1px solid #3498db; padding: 10px; border-radius: 5px;">4. Cancel Booking</div>

  - **Endpoint:** `DELETE /api/booking/{id:int}`
- **Description:** Cancel a specific booking by ID.
- **Permissions:**
  - [x] RemoveBooking
- **Parameters:**
  - `id`: Booking ID
- **Response:**
  - Status 204 No Content: Booking successfully canceled.
  - Status 401 Unauthorized: User is not authenticated.
### License
```vb
Feel free to customize the content based on your project's specifics and additional details you want to include.
```

