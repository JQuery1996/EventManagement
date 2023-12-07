# Event Management System
___

A web-based application that allows users to create, manage, and participate in events.

## .NET Version
This project is built using .NET Core 8.
## Table of Contents

1. [Authentication Controller](#authentication-controller)
   - [Login](#login)
   - [Register](#register)
   
2. [User Controller](#user-controller)
   - [Get All Users](#1-get-all-users)
   - [Get User by ID](#2-get-user-by-id)
   - [Filter Users](#3-filter-users)
   - [Edit User](#4-edit-user)
   - [Remove User](#5-remove-user)

3. [Role Controller](#role-controller)
   - [Assign Role to User](#1-assign-role-to-user)

4. [Permission Controller](#permission-controller)
   - [List All Permissions](#1-list-all-permissions)
   - [List Permissions for Role](#2-list-permissions-for-role)
   - [Add Permission to Role](#3-add-permission-to-role)

5. [Event Controller](#event-controller)
   - [Get All Events](#1-get-all-events)
   - [Get Event by ID](#2-get-event-by-id)
   - [Create Event](#3-create-event)
   - [Update Event](#4-update-event)
   - [Remove Event](#5-remove-event)

6. [Booking Controller](#booking-controller)
   - [Create Booking](#1-create-booking)
   - [Get Booking](#2-get-booking)
   - [Edit Booking](#3-edit-booking)
   - [Cancel Booking](#4-cancel-booking)

7. [License](#license)

## Authentication Controller

The `AuthenticationController` handles authentication-related endpoints.

### Endpoints

#### Login

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
#### Register

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

### 1. Get All Users

- **Endpoint:** `GET /api/user`
- **Description:** Retrieve a list of all users.
- **Permissions:**
  - [x] ViewUsers
- **Response:**
  - Status 200 OK: Returns a list of user details.
  - Status 401 Unauthorized: User is not authenticated.
  - Status 403 Forbidden: User lacks the necessary permissions.
### 2. Get User by ID

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
### 3. Filter Users

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

### 4. Edit User

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

### 5. Remove User

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

### 1. Assign Role to User
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

### 1. List All Permissions

- **Endpoint:** `GET /api/permission/Permissions`
- **Description:** Retrieve a list of all permissions.
- **Permissions:**
  - [x] ViewPermissions
- **Response:**
  - Status 200 OK: Returns a list of permission details.
  - Status 401 Unauthorized: User is not authenticated.
  - Status 403 Forbidden: User lacks the necessary permissions. 
### 2. List Permissions for Role
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
  
### 3. Add Permission to Role
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

### 1. Get All Events
- **Endpoint:** `GET /api/event`
- **Description:** Retrieve a list of all available events.
- **Permissions:**
  - [x] ViewEvents
- **Response:**
  - Status 200 OK: Returns a list of event details.
  - Status 401 Unauthorized: User is not authenticated.
  - Status 403 Forbidden: User lacks the necessary permissions.
### 2. Get Event by ID

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
### 3. Create Event
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

### 4. Update Event
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

### 5. Remove Event
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
 
## Booking Controller

The `BookingController` manages booking-related operations.

### 1. Create Booking

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

### 2. Get Booking

- **Endpoint:** `GET /api/booking`
- **Description:** Retrieve bookings for the authenticated user.
- **Permissions:**
  - [x] ViewBookings
- **Response:**
  - Status 200 OK: Returns a list of booking details.
  - Status 204 No Content: No bookings found for the user.
  - Status 401 Unauthorized: User is not authenticated.

### 3. Edit Booking

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
 
### 4. Cancel Booking

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

