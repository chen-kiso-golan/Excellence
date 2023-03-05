--Q1 
--���� STP ����� 2 ������ ������ � 4 SELECTS �� ������ ������, �����, �����, ����� 
CREATE PROCEDURE calcOperations (@num1 INT, @num2 INT)
AS
BEGIN
    SELECT @num1 + @num2 AS Addition
    SELECT @num1 - @num2 AS Subtraction
    SELECT @num1 * @num2 AS Multiplication
    SELECT @num1 / @num2 AS Division
END

--Q2
--���� STP ����� ���� nums  �� ����� ����� ������� num1.num2 � id ���� ���� identity 
CREATE PROCEDURE createNumsTable
AS
BEGIN
    CREATE TABLE nums (
        id INT IDENTITY PRIMARY KEY,
        num1 INT,
        num2 INT
    )
END

--Q3
--���� STP ����� 2 ������� ������� ������ ����� nums �� ��� ������� 
CREATE PROCEDURE insertNums (@num1 INT, @num2 INT)
AS
BEGIN
    INSERT INTO nums (num1, num2) VALUES (@num1, @num2)
END


--Q4
--���� ����� �����, ����� ������� ������ ���� � IDENTITY ���� �� ������ ��� ����� �� ������ �� ���� ���� ���� 
CREATE PROCEDURE insertNumsAndReverseIfIdMatch (@num1 INT, @num2 INT)
AS
BEGIN
    DECLARE @id INT
    INSERT INTO nums (num1, num2) VALUES (@num1, @num2)
    SET @id = SCOPE_IDENTITY()
    IF @id = @num1
        INSERT INTO nums (num1, num2) VALUES (@num2, @num1)
END


--Q5
--���� ����� ������, ����� ������� ������ ���� � 8 �� ����� �� �� ������� ����� ��� 1 ����� 2 
CREATE PROCEDURE updateNumsIfFirstParam8
AS
BEGIN
    UPDATE nums SET num1 = 2 WHERE num1 = 1
END


--Q6
--���� ����� ������, ����� ������� ������ ���� � 9 �� ����� �� �� ������� ������������ � 1 
CREATE PROCEDURE updateNumsIfFirstParam9
AS
BEGIN
    UPDATE nums SET num1 = num1 + 1, num2 = num2 + 1
END


--Q7
--���� ����� ������, ����� ������� ������ ���� �10  �� ����� �� �� ������� ������ �� ��� ������� ���� � 100 
CREATE PROCEDURE deleteNumsIfFirstParam10
AS
BEGIN
    DELETE FROM nums WHERE num1 + num2 > 100
END


--Q10-12
--���� STP ��� calcNums  ����� 3 ������� ������� ������ ����� nums �� ������ ������ ��� ������ ����� ���� ���� ������� ���� ���� 
--������ �STP �� �� ������� ����� � identity ������ ����� ���� ��� ���� �� ����� �� num1 ����� ���� ����� ��� + ���� �� identity ���� �id ������. �"� �� identity ��� 12 num1=30, ��� ��� ���� �� ���� ����� ���� num1 ���� ������ � 42 ���� id=12 
--������ � STP �� �� ������� ����� � STP ��� ���� ������ � ID ���� ���� ��� num2 ���� � 100  
CREATE PROCEDURE calcNums
    @num1 int,
    @num2 int,
    @num3 int
AS
BEGIN
    DECLARE @max_num int;
    IF @num2 > @num3
        SET @max_num = @num2;
    ELSE
        SET @max_num = @num3;

    INSERT INTO nums (num1, num2)
    VALUES (@num1, @max_num);

    DECLARE @last_id int = SCOPE_IDENTITY();
    IF @last_id % 2 = 0
    BEGIN
        UPDATE nums
        SET num1 = num1 + @last_id
        WHERE id = @last_id;
    END

    DELETE FROM nums
    WHERE id % 2 = 0 AND num2 > 100;
END


--Q13
--���� STP  ��� ����� ����� ����� , � STP ���� ���� ������� ����� nums ��� ������ ������. ����� ��� �� ���� �� �� ������� � num1 ���� ������� (��� select count(*)( 
CREATE PROCEDURE checkNums
    @param INT
AS
BEGIN
    DECLARE @count INT
    
    SELECT @count = COUNT(*) FROM nums
    
    IF @count < @param
    BEGIN
        SELECT * FROM nums WHERE num1 > @param
    END
END


--Q14-16
--��� 2 ������ ����� a,b ������ �� ��� ����� aa,bb ������� (������ �� ������ �STP ����� ����� 2 
--���� STP  ����� 2 ������� ������� ������ � 2 ������� ������ �� ��� ������� ������, ���� ���� b �� ������ ��� ����� �����, ���� ���� ������ aa ���� ���� ������ ������� bb ���� ����� ���� �����. �"� ���� ����� b ���� �� ����� ������ ����� a 
--���� STP ������ 2 ������� ������ �� ���� b ��� ������ �� ������� �������� . ������ �� �������� ��� 4,6 �� ����� ����� b �� �� ������ ����� aa ���� � 4 ���� � 6. ����� ������� ������ ���� ����� �� ����� �� �� ������ ���� 
CREATE TABLE a (
  aa NUMERIC,
  bb NUMERIC
);

CREATE TABLE b (
  aa NUMERIC,
  bb NUMERIC
);


CREATE PROCEDURE addNumsToTables (@num1 NUMERIC, @num2 NUMERIC)
AS
BEGIN
    -- Add num1 and num2 to table a
    INSERT INTO a (aa, bb) VALUES (@num1, @num2);

    -- Add num1 and num2 to table b
    INSERT INTO b (aa, bb) VALUES (@num1, @num2);

    -- Add one more row to table b with aa same as previous and bb equal to @num2 * 2
    INSERT INTO b (aa, bb) VALUES (@num1, @num2 * 2);

END;


CREATE PROCEDURE getRowsFromB (@minAA NUMERIC, @maxAA NUMERIC)
AS
BEGIN
    -- Swap the values of @minAA and @maxAA if @minAA is greater than @maxAA
    IF @minAA > @maxAA
    BEGIN
        DECLARE @temp NUMERIC;
        SET @temp = @minAA;
        SET @minAA = @maxAA;
        SET @maxAA = @temp;
    END

    -- Retrieve rows from table b based on the minimum and maximum values of column aa
    SELECT * FROM b WHERE aa > @minAA AND aa < @maxAA;
END;


