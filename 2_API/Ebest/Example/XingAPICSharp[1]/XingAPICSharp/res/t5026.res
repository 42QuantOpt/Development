BEGIN_FUNCTION_MAP
    .Func,일괄청산주문/가능여부조회(t5026),t5026,base21=SONBT701,headtype=B;
    BEGIN_DATA_MAP
    t5026InBlock,기본입력,input;
    begin
	    레코드갯수              ,reccnt       ,reccnt       ,   long, 5   ;
	    계좌번호                ,accno        ,accno        ,   char, 20  ;
	    입력비밀번호            ,passwd       ,passwd       ,   char, 8   ;
	    조회처리구분            ,qrygb        ,qrygb        ,   char, 1   ;
	    선물옵션거래유형코드    ,fotradgb     ,fotradgb     ,   char, 2   ;
	    통신매체코드            ,tongsingb    ,tongsingb    ,   char, 2   ;
	    처리구분                ,gb           ,gb           ,   char, 1   ;
    end
    t5026OutBlock,기본출력,output;
    begin
	    레코드갯수              ,reccnt       ,reccnt       ,   long, 5   ;
	    계좌번호                ,accno        ,accno        ,   char, 20  ;
	    입력비밀번호            ,passwd       ,passwd       ,   char, 8   ;
	    조회처리구분            ,qrygb        ,qrygb        ,   char, 1   ;
	    선물옵션거래유형코드    ,fotradgb     ,fotradgb     ,   char, 2   ;
	    통신매체코드            ,tongsingb    ,tongsingb    ,   char, 2   ;
	    처리구분                ,gb           ,gb           ,   char, 1   ;
    end
    t5026OutBlock1,기본출력1,output;
    begin
	    레코드갯수              ,reccnt       ,reccnt       ,   long, 5   ;
	    계좌명                  ,accno        ,accno        ,   char, 40  ;
	    주문처리구분            ,ordgb        ,ordgb        ,   char, 1   ;
	    주문처리구분명          ,ordgbnm      ,ordgbnm      ,   char, 20  ;
    end
    t5026OutBlock2,기본출력2,output,occurs;
    begin
	    순서                    ,seq          ,seq          ,   long, 4   ;
	    선물옵션종목유형구분    ,offergb      ,offergb      ,   char, 1   ;
	    선물옵션종목번호        ,focode       ,focode       ,   char, 32  ;
	    매매구분                ,mmgb         ,mmgb         ,   char, 1   ;
	    매매구분명              ,mmgbnm       ,mmgbnm       ,   char, 10  ;
	    미결제수량              ,openyak      ,openyak      ,   long, 16  ;
	    미체결수량              ,micheqty     ,micheqty     ,   long, 16  ;
	    현재가                  ,price        ,price        ,   double, 13.2;
	    반대호가수량            ,banhoqty     ,banhoqty     ,   long, 16  ;
	    주문처리구분            ,ordgb        ,ordgb        ,   char, 1   ;
	    주문처리구분명          ,ordgbnm      ,ordgbnm      ,   char, 20  ;
    end
    END_DATA_MAP
END_FUNCTION_MAP
