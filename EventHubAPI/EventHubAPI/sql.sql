ALTER TABLE Events
    ADD CategoryId INT NULL 
    CONSTRAINT category_id DEFAULT 1 
    WITH VALUES;