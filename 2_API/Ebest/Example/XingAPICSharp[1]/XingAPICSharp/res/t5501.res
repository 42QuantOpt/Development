BEGIN_FUNCTION_MAP
	.Func,현물정상주문(t5501),t5501,base21=SONAT000,headtype=B;
	BEGIN_DATA_MAP
	t5501InBlock,입력,input;
	begin
		레코드갯수,	reccnt,	reccnt,	long,	5;
		계좌번호,	accno,	accno,	char,	20;
		입력비밀번호,	passwd,	passwd,	char,	8;
		종목번호,	expcode,	expcode,	char,	12;
		주문수량,	qty,	qty,	long,	16;
		주문가,	price,	price,	double,	13.2;
		매매구분,	memegb,	memegb,	char,	1;
		호가유형코드,	hogagb,	hogagb,	char,	2;
		프로그램호가유형코드,	pgmtype,	pgmtype,	char,	2;
		공매도가능여부,	gongtype,	gongtype,	char,	1;
		공매도호가구분,	gonghoga,	gonghoga,	char,	1;
		통신매체코드,	tongsingb,	tongsingb,	char,	2;
		신용거래코드,	sinmemecode,	sinmemecode,	char,	3;
		대출일,	loandt,	loandt,	char,	8;
		회원번호,	memnumber,	memnumber,	char,	3;
		주문조건구분,	ordcondgb,	ordcondgb,	char,	1;
		전략코드,	stragb,	stragb,	char,	6;
		그룹ID,	groupid,	groupid,	char,	20;
		주문회차,	ordernum,	ordernum,	long,	10;
		포트폴리오번호,	portnum,	portnum,	long,	10;
		바스켓번호,	basketnum,	basketnum,	long,	10;
		트렌치번호,	tranchnum,	tranchnum,	long,	10;
		아이템번호,	itemnum,	itemnum,	long,	10;
		운용지시번호,	operordnum,	operordnum,	char,	12;
		유동성공급자여부,	flowsupgb,	flowsupgb,	char,	1;
		반대매매구분,	oppbuygb,	oppbuygb,	char,	1;
	end
	t5501OutBlock,출력,output;
	begin
		레코드갯수,	reccnt,	reccnt,	long,	5;
		계좌번호,	accno,	accno,	char,	20;
		입력비밀번호,	passwd,	passwd,	char,	8;
		종목번호,	expcode,	expcode,	char,	12;
		주문수량,	qty,	qty,	long,	16;
		주문가,	price,	price,	double,	13.2;
		매매구분,	memegb,	memegb,	char,	1;
		호가유형코드,	hogagb,	hogagb,	char,	2;
		프로그램호가유형코드,	pgmtype,	pgmtype,	char,	2;
		공매도가능여부,	gongtype,	gongtype,	char,	1;
		공매도호가구분,	gonghoga,	gonghoga,	char,	1;
		통신매체코드,	tongsingb,	tongsingb,	char,	2;
		신용거래코드,	sinmemecode,	sinmemecode,	char,	3;
		대출일,	loandt,	loandt,	char,	8;
		회원번호,	memnumber,	memnumber,	char,	3;
		주문조건구분,	ordcondgb,	ordcondgb,	char,	1;
		전략코드,	stragb,	stragb,	char,	6;
		그룹ID,	groupid,	groupid,	char,	20;
		주문회차,	ordernum,	ordernum,	long,	10;
		포트폴리오번호,	portnum,	portnum,	long,	10;
		바스켓번호,	basketnum,	basketnum,	long,	10;
		트렌치번호,	tranchnum,	tranchnum,	long,	10;
		아이템번호,	itemnum,	itemnum,	long,	10;
		운용지시번호,	operordnum,	operordnum,	char,	12;
		유동성공급자여부,	flowsupgb,	flowsupgb,	char,	1;
		반대매매구분,	oppbuygb,	oppbuygb,	char,	1;
	end
	t5501OutBlock1,출력1,output;
	begin
		레코드갯수,	reccnt,	reccnt,	long,	5;
		주문번호,	ordno,	ordno,	long,	10;
		주문시각,	ordtime,	ordtime,	char,	9;
		주문시장코드,	ordmktcode,	ordmktcode,	char,	2;
		주문유형코드,	ordcode,	ordcode,	char,	2;
		단축종목번호,	expcode,	expcode,	char,	9;
		관리사원번호,	operno,	operno,	char,	9;
		주문금액,	ordamt,	ordamt,	long,	16;
		예비주문번호,	fillermemegb,	fillermemegb,	long,	10;
		반대매매일련번호,	oppbuyseqno,	oppbuyseqno,	long,	10;
		예약주문번호,	preeordno,	preeordno,	long,	10;
		실물주문수량,	realordcnt,	realordcnt,	long,	16;
		재사용주문수량,	recoordcnt,	recoordcnt,	long,	16;
		현금주문금액,	cashordamt,	cashordamt,	long,	16;
		대용주문금액,	daeordamt,	daeordamt,	long,	16;
		재사용주문금액,	recordamt,	recordamt,	long,	16;
		계좌명,	accno,	accno,	char,	40;
		종목명,	hname,	hname,	char,	40;
	end
	END_DATA_MAP
END_FUNCTION_MAP
