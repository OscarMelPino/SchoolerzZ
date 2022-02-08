drop function if exists GenerateLicence;
DELIMITER //
CREATE FUNCTION GenerateLicence()
returns varchar(29)
begin
	declare vi_r int;
	declare vv_word varchar(29);
    declare vi_cont int;
    declare vi_cont_2 int;
    set vi_cont = 0;
    set vi_cont_2 = 0;
    set vv_word = '';
    WHILE vi_cont < 29 DO
        if vi_cont_2 = 5 then
			set vv_word = concat(vv_word, '-');
            set vi_cont = vi_cont + 1;
            set vi_cont_2 = 0;
		else
			set vv_word = concat(vv_word, upper(substr('abcdefghijklmnopqrstuvwxyz1234567890', floor(rand()*35), 1)));
			set vi_cont = vi_cont + 1;
            set vi_cont_2 = vi_cont_2 + 1;
        end if;
    END WHILE;
	RETURN vv_word;
end
// DELIMITER ;

drop function if exists Login;

DELIMITER //
CREATE FUNCTION Login(pc_Type char, pv_Nick varchar(15), pv_Password varchar(200)) 
RETURNS INT
BEGIN
    declare vv_nick varchar(15);
    declare vi_r int;
    
    set vv_nick = concat(upper(pc_Type), upper(pv_Nick));
    
    if pc_Type like upper('S') then
		if ((select SZ_002_Id from sz_002_students where SZ_002_Nick like vv_Nick and SZ_002_Password like pv_Password) <=> NULL) or ((select SZ_002_Deleted from sz_002_students where SZ_002_Nick like vv_Nick and SZ_002_Password like pv_Password) = 1) then
            set vi_r = -1;
        else
            set vi_r = 1;
        end if;
    else
		if pc_Type like upper('M') then
			if ((select SZ_007_Id from SZ_007_School_Managers where SZ_007_Nick like vv_Nick and SZ_007_Password like pv_Password) <=> NULL) or ((select SZ_007_Deleted from SZ_007_School_Managers where SZ_007_Nick like vv_Nick and SZ_007_Password like pv_Password) = 1) then
				set vi_r = -2;
			else
				set vi_r = 2;
			end if;
        else
			if pc_Type like upper('p') then
				if ((select SZ_003_Id from SZ_003_Parents where SZ_007_Nick like vv_Nick and SZ_003_Parents like pv_Password) <=> NULL) or ((select SZ_003_Deleted from SZ_003_Parents where SZ_003_Nick like vv_Nick and SZ_007_Password like pv_Password) = 1) then
					set vi_r = -3;
				else
					set vi_r = 3;
				end if;
            else
				if pc_Type like upper('t') then
					 if ((select SZ_008_Id from SZ_008_Teachers where SZ_008_Nick like vv_Nick and SZ_008_Password like pv_Password) <=> NULL) or ((select SZ_008_Deleted from SZ_008_Teachers where SZ_008_Nick like vv_Nick and SZ_008_Password like pv_Password) = 1) then
						set vi_r = -4;
					else
						set vi_r = 4;
					end if;
				end if;
            end if;
        end if;
    end if;
    return vi_r;
end
// DELIMITER ;
        
drop function if exists CreatePassword;

DELIMITER //
CREATE FUNCTION CreatePassword() 

       RETURNS varchar(8)
BEGIN
	declare vv_word varchar(8);
	set vv_word = concat(upper(substr('abcdefghijklmnopqrstuvwxyz', floor(rand()*25), 1)));
	set vv_word = concat(vv_word, substr('abcdefghijklmnopqrstuvwxyz', floor(rand()*25), 1));
    set vv_word = concat(vv_word, substr('1234567890', floor(rand()*9), 1));
    set vv_word = concat(vv_word, substr('1234567890', floor(rand()*9), 1));
    set vv_word = concat(vv_word, substr('%$&#-@/+', floor(rand()*7), 1));
    set vv_word = concat(vv_word, substr('abcdefghijklmnopqrstuvwxyz', floor(rand()*25), 1));
    set vv_word = concat(vv_word, substr('%$&#-@/+', floor(rand()*7), 1));
    set vv_word = concat(vv_word, upper(substr('abcdefghijklmnopqrstuvwxyz', floor(rand()*25), 1)));
    RETURN vv_word;
END
// DELIMITER ;
        
