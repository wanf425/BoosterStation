CREATE TABLE plchistorydata (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    TempIn1 TEXT,
    TempIn2 TEXT,
    TempOut TEXT,
    PressureTank1 TEXT,
    PressureTank2 TEXT,
    LevelTank1 TEXT,
    LevelTank2 TEXT,
    PressureTankOut TEXT,
    CreateTime TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    CreateUser TEXT NOT NULL,
    UpdateTime TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdateUser TEXT NOT NULL
);