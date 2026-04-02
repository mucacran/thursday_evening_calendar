# List View Next Phase DB

## Remaining DB Wiring Tasks

- Add the real EF Core database provider package for the target database.
- Move the real connection string into the correct appsettings file.
- Decide whether `meetingContext` should stay in-memory for development only or switch fully to the real provider.
- Replace the mock list in `GET /api/events` with a simple EF query when the database is ready.

## Schema And Naming Items To Resolve Later

- Align the write model name `Course_Id` with the read response name `CourseId`.
- Confirm whether the `Meetings` table name should stay as-is or be renamed to match the `Event` class more clearly.
- Review database column names such as `course_id` and decide on one consistent naming style across C#, JSON, and SQL.
- Check whether nullable text fields need database constraints or default values.

## Migration And Testing Checklist

- Add or confirm the final provider configuration and connection string.
- Create and apply the database migration.
- Seed a few test records for the list page.
- Update `GET /api/events` to read from EF instead of mock data.
- Verify `GET /api/events` returns real rows and an empty list when no rows exist.
- Verify the `/events` page still shows loading, empty, and error states correctly.
- Regression test the existing `PUT /api/events` flow after the read path is switched to EF.