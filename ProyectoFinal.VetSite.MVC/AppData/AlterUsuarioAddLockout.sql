ALTER TABLE Usuario
ADD FailedLoginAttempts INT NOT NULL DEFAULT 0,
    LockoutEnd DATETIME NULL;
