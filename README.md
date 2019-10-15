# Assignment - Scandic

```
Your task is to:
1 Define the interface towards the communication module
2 Implement the business logic as described above
3 Verify that the implementation works as described above
4 Describe any additional assumptions you have made about the problem
```

Assumptions
- Since I can only AddGuestToBooking I made an assuption that I cannot upgrade a customers room and cause of that adding a new guest have to fail if there is not enough room.
- HandleNewGuest should probably have a return value to let the customer/guest know if adding the new guest was successful. I left it as void since I don't know how the rest of the system is setup.


Additional information
The helpers folder can be ignored.
It was a fun experiment I made that can handle the title requirement on German bookings directly in modelstate using a custom attribute.
