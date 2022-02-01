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
			set vv_word = concat(vv_word, upper(substr('abcdefghijklmnopqrstuvwxyz1234567890', floor(rand()*36), 1)));
			set vi_cont = vi_cont + 1;
            set vi_cont_2 = vi_cont_2 + 1;
        end if;
    END WHILE;
	RETURN vv_word;
end 
// DELIMITER ;



