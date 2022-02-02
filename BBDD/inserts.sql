INSERT INTO `schoolerzz`.`sz_006_schools`
(`SZ_006_Id`,
`SZ_006_Name`,
`SZ_006_SchoolCode`,
`SZ_006_Words3`,
`SZ_006_Country`,
`SZ_006_City`,
`SZ_006_PostalCode`,
`SZ_006_Address`)
VALUES
(UUID_TO_BIN(UUID()),'Joyfe',12354,'JOY','Spain', 'Madrid',28017,'c/ Vital Aza, 65');

INSERT INTO `schoolerzz`.`sz_007_school_managers`
(`SZ_007_Id`,
`SZ_007_Name`,
`SZ_007_SN1`,
`SZ_007_SN2`,
`SZ_007_Birth`,
`SZ_007_Nationality`,
`SZ_007_Country`,
`SZ_007_City`,
`SZ_007_PostalCode`,
`SZ_007_Address`,
`SZ_007_Email`,
`SZ_007_Phone1`,
`SZ_007_Nick`,
`SZ_007_Password`,
`SZ_007_Schools_Id`
)
VALUES
(UUID_TO_BIN(UUID()),'María Teresa','Martínez', 'Puche', curdate(),'Spanish','Spain','Madrid','28017','Calle Peter Peter, 4 2Z','mtere@mt.com','+34555555555', 'MJOY-MAMAPU', '1234', (SELECT SZ_006_Id FROM sz_006_schools limit 1));

INSERT INTO `schoolerzz`.`sz_008_teachers`
(`SZ_008_Id`,
`SZ_008_Name`,
`SZ_008_SN1`,
`SZ_008_SN2`,
`SZ_008_Birth`,
`SZ_008_Nationality`,
`SZ_008_Country`,
`SZ_008_City`,
`SZ_008_PostalCode`,
`SZ_008_Address`,
`SZ_008_Email`,
`SZ_008_Password`,
`SZ_008_Phone1`
)
VALUES
(UUID_TO_BIN(UUID()), 'Guillermo','Pérez', 'Tomé',curdate(),'Spanish','Spain','Madrid','28017','Calle Colegio, 4 2Z','guille@gu.com','1234', '+34111111111');

INSERT INTO `schoolerzz`.`sz_002_students`
(`SZ_002_Id`,
`SZ_002_Name`,
`SZ_002_SN1`,
`SZ_002_SN2`,
`SZ_002_Birth`,
`SZ_002_Nationality`,
`SZ_002_Country`,
`SZ_002_City`,
`SZ_002_PostalCode`,
`SZ_002_Address`,
`SZ_002_Email`,
`SZ_002_Password`
)
VALUES
(UUID_TO_BIN(UUID()), 'Óscar Vicente','Melgarejo', 'Pino',curdate(),'Spanish','Spain','Madrid','28017','Call Carmencita, 4 2Z','oscar@os.com','1234');

INSERT INTO `schoolerzz`.`sz_003_parents`
(`SZ_003_Id`,
`SZ_003_Name`,
`SZ_003_SN1`,
`SZ_003_SN2`,
`SZ_003_Birth`,
`SZ_003_Nationality`,
`SZ_003_Country`,
`SZ_003_City`,
`SZ_003_PostalCode`,
`SZ_003_Address`,
`SZ_003_Email`,
`SZ_003_Password`,
`SZ_003_Phone1`
)
VALUES
(UUID_TO_BIN(UUID()), 'Pater','Noster', 'Muy Noster',curdate(),'Spanish','Spain','Madrid','28017','Calle Yo Claudio, 4 2Z','Pater@pa.com','1234', '+34666666666');

INSERT INTO `schoolerzz`.`sz_203_students_parents`
(`SZ_203_Id`,
`SZ_203_Students_Id`,
`SZ_203_Parents_Id`
)
VALUES
(UUID_TO_BIN(UUID()), (SELECT SZ_002_Id FROM sz_002_students limit 1) , (SELECT SZ_003_Id FROM sz_003_parents limit 1));

INSERT INTO `schoolerzz`.`sz_005_skins`
(`SZ_005_Id`,
`SZ_005_Name`,
`SZ_005_Description`,
`SZ_005_Route`
)
VALUES
(UUID_TO_BIN(UUID()),'Bic Cristal Rojo', 'Skin de Boli Bic Cristal Rojo super molona', 'C:/SchoolerzZ/Skins/bic_rojo.png');

INSERT INTO `schoolerzz`.`sz_205_students_skins`
(`SZ_205_Id`,
`SZ_205_Students_Id`,
`SZ_205_Skins_Id`
)
VALUES
(UUID_TO_BIN(UUID()),(SELECT SZ_002_Id FROM sz_002_students limit 1), (SELECT SZ_005_Id FROM sz_005_skins limit 1));

INSERT INTO `schoolerzz`.`sz_004_emblems`
(`SZ_004_Id`,
`SZ_004_Name`,
`SZ_004_Description`
)
VALUES
(UUID_TO_BIN(UUID()),'Pitagorín', 'Eres el más rápido en cálculo mental');

INSERT INTO `schoolerzz`.`sz_204_students_emblems`
(`SZ_204_Id`,
`SZ_204_Students_Id`,
`SZ_204_Emblems_Id`
)
VALUES
(UUID_TO_BIN(UUID()),(SELECT SZ_002_Id FROM sz_002_students limit 1), (SELECT SZ_004_Id FROM sz_004_emblems limit 1));

INSERT INTO `schoolerzz`.`sz_001_groups`
(
	`SZ_001_Id`,
    `SZ_001_Stage`,
    `SZ_001_Level`,
    `SZ_001_Class`,
    `SZ_001_Schools_Id`,
    `SZ_001_Teachers_Id`
)
VALUES
(UUID_TO_BIN(UUID()),'Primaria', 1, 'A', (SELECT SZ_006_Id FROM sz_006_schools limit 1), (SELECT SZ_008_Id FROM sz_008_teachers limit 1));

INSERT INTO `schoolerzz`.`sz_102_groups_students`
(
	`SZ_102_Id`,
    `SZ_102_Groups_Id`,
    `SZ_102_Students_Id`
)
VALUES
(UUID_TO_BIN(UUID()),(SELECT SZ_001_Id FROM sz_001_groups limit 1), (SELECT SZ_002_Id FROM sz_002_students limit 1));

INSERT INTO `schoolerzz`.`sz_009_activities`
(
    `SZ_009_Id`,
    `SZ_009_Title`,
    `SZ_009_Deadline`,
    `SZ_009_CreationDate`,
    `SZ_009_UpdateDate`,
    `SZ_009_Route`,
    `SZ_009_Content`
)
VALUES
(UUID_TO_BIN(UUID()),'Juego Triángulos', '1996-11-22', '1996-11-21', curdate(), 'C:/SchoolerzZ/Activities/tri_game.exe', '-Formas Geométricas -Identificación de Triángulos');

INSERT INTO `schoolerzz`.`sz_109_groups_activities`
(
    `SZ_109_Id`,
    `SZ_109_Groups_Id`,
    `SZ_109_Activities_Id`
)
VALUES
(UUID_TO_BIN(UUID()),(SELECT SZ_001_Id FROM sz_001_groups limit 1), (SELECT SZ_009_Id FROM sz_009_activities limit 1));

INSERT INTO `schoolerzz`.`sz_012_chats`
(
    `SZ_012_Id`,
    `SZ_012_Name`,
    `SZ_012_Image_Route`,
    `SZ_012_Group_Id`
)
VALUES
(UUID_TO_BIN(UUID()),'1A', 'C:/SchoolerzZ/Chats/chat1A.txt', (SELECT SZ_001_Id FROM sz_001_groups limit 1));

INSERT INTO `schoolerzz`.`sz_013_messages`
(
    `SZ_013_Id`,
    `SZ_013_Body`,
    `SZ_013_Sent_Date`,
    `SZ_013_Chats_Id`
)
VALUES
(UUID_TO_BIN(UUID()),'Primer Mensaje', curdate(), (SELECT SZ_012_Id FROM sz_012_chats limit 1));

INSERT INTO `schoolerzz`.`sz_014_teachers_skins`
(`SZ_014_Id`,
`SZ_014_Name`,
`SZ_014_Description`,
`SZ_014_Route`
)
VALUES
(UUID_TO_BIN(UUID()),'Pilot Verde', 'Skin de Pilot Verde de Aprobar', 'C:/SchoolerzZ/Teachers_Skins/pilot_verde.png');

INSERT INTO `schoolerzz`.`sz_8014_teachers_teachers_skins`
(
    `SZ_8014_Id`,
    `SZ_8014_Teachers_Id`,
    `SZ_8014_Teachers_Skins_Id`
) 
VALUES 
(UUID_TO_BIN(UUID()),(SELECT SZ_008_Id FROM sz_008_teachers limit 1), (SELECT SZ_014_Id FROM sz_014_teachers_skins limit 1));

INSERT INTO `schoolerzz`.`sz_010_Threads`
(
	`SZ_010_Id`,
    `SZ_010_Title`,
    `SZ_010_CreationDate`,
    `SZ_010_Teacher_Id`
)
VALUES 
(UUID_TO_BIN(UUID()),'Actividades 1A', curdate(), (SELECT SZ_008_Id FROM sz_008_teachers limit 1));

INSERT INTO `schoolerzz`.`sz_011_posts`
(
	`SZ_011_Id`,
    `SZ_011_Title`,
    `SZ_011_CreationDate`,
    `SZ_011_Body`,
    `SZ_011_Teacher_Id`,
    `SZ_011_Threads_Id`
)
VALUES 
(UUID_TO_BIN(UUID()),'Primer Post', curdate(), 'Body primer post', (SELECT SZ_008_Id FROM sz_008_teachers limit 1), (SELECT SZ_010_Id FROM sz_010_threads limit 1));