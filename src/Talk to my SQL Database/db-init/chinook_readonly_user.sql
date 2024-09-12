CREATE ROLE chinook_reader WITH LOGIN PASSWORD 'StrongPassw0rd';
GRANT CONNECT ON DATABASE chinook TO chinook_reader;
GRANT SELECT ON ALL TABLES IN SCHEMA public TO chinook_reader;
