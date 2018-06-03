BEGIN_FUNCTION_MAP
	.Func,현물복수정상주문,t5101,base21=SONAT016,headtype=B;
	BEGIN_DATA_MAP

	t5101InBlock,입력,input;
	begin
		레코드갯수			,	reccnt		,	reccnt		,	long	,	5;
		통신매체코드		,	tongsingb	,	tongsingb	,	char	,	2;
		현물주문횟수		,	ordercnt	, 	ordercnt	,	long	,	6;
		레코드갯수1			,	reccnt1		,	reccnt1		,	long	,	5;
	end
	t5101InBlock1,입력,input,occurs;
	begin
		주문처리구분		,	ordergb		,	ordergb		, 	char	,	1;
		원주문번호			,	orgordno	,	orgordno	,	long	,	10;
		계좌번호			,	accno		,	accno		,	char	,	20;
		입력비밀번호		,	passwd		,	passwd		,	char	,	8;
		매매구분			,	memegb		,	memegb		,	char	,	1;
		종목번호			,	expcode		,	expcode		,	char	,	12;
		주문수량			,	qty			,	qty			,	long	,	16;
		주문가				,	price		,	price		,	double	,	13.2;
		호가유형코드		,	hogagb		,	hogagb		,	char	,	2;
		공매도가능여부		,	gongtype	,	gongtype	,	char	,	1;
		공매도호가구분      ,   ghogagb     ,   ghogagb     ,   char    ,   1;
		주문조건구분		,	ordcondgb	,	ordcondgb	,	char	,	1;
		프로그램호가유형코드,	pgmtype		,	pgmtype		,	char	,	2;
		운용지시번호		,	operordnum	,	operordnum	,	char	,	12;
		신용거래코드		,   sincd	    ,   sincd       ,   char    ,   3;
		대출일				,   loandt      ,   loandt      ,   char    ,   8;
		유동성공급자여부    ,   flowsupgb   ,   flowsupgb   ,   char    ,   1;
		복수주문일련번호	,	multiordno	,	multiordno	,	long	,	10;
		주문번호			,	ordno		,	ordno		,	long	,	10;
		메세지코드			,	msgcode		,	msgcode		,	char	,	4;
		메세지내용			,	msg			,	msg			,	char	,	100;
		처리시각			,	proctm		,	proctm		,	char	,	9;
	end
	t5101OutBlock,입력,output;
	begin
		레코드갯수			,	reccnt		,	reccnt		,	long	,	5;
		통신매체코드		,	tongsingb	,	tongsingb	,	char	,	2;
		현물주문횟수		,	ordercnt	, 	ordercnt	,	long	,	6;
	end
	t5101OutBlock1,입력,output,occurs;
	begin
		주문처리구분		,	ordergb		,	ordergb		, 	char	,	1;
		원주문번호			,	orgordno	,	orgordno	,	long	,	10;
		계좌번호			,	accno		,	accno		,	char	,	20;
		입력비밀번호		,	passwd		,	passwd		,	char	,	8;
		매매구분			,	memegb		,	memegb		,	char	,	1;
		종목번호			,	expcode		,	expcode		,	char	,	12;
		주문수량			,	qty			,	qty			,	long	,	16;
		주문가				,	price		,	price		,	double	,	13.2;
		호가유형코드		,	hogagb		,	hogagb		,	char	,	2;
		공매도가능여부		,	gongtype	,	gongtype	,	char	,	1;
		공매도호가구분      ,   ghogagb     ,   ghogagb     ,   char    ,   1;
		주문조건구분		,	ordcondgb	,	ordcondgb	,	char	,	1;
		프로그램호가유형코드,	pgmtype		,	pgmtype		,	char	,	2;
		운용지시번호		,	operordnum	,	operordnum	,	char	,	12;
		신용거래코드		,   sincd	    ,   sincd       ,   char    ,   3;
		대출일				,   loandt      ,   loandt      ,   char    ,   8;
		유동성공급자여부    ,   flowsupgb   ,   flowsupgb   ,   char    ,   1;
		복수주문일련번호	,	multiordno	,	multiordno	,	long	,	10;
		주문번호			,	ordno		,	ordno		,	long	,	10;
		메세지코드			,	msgcode		,	msgcode		,	char	,	4;
		메세지내용			,	msg			,	msg			,	char	,	100;
		처리시각			,	proctm		,	proctm		,	char	,	9;
	end
	END_DATA_MAP
END_FUNCTION_MAP
