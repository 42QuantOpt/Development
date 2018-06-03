BEGIN_FUNCTION_MAP
    .Func,선물/옵션복수계좌복수종목주문(취소)(t5011),t5011,base21=SONBT714,headtype=B;
    BEGIN_DATA_MAP
    t5011InBlock,기본입력,input;
    begin
        레코드갯수                           ,reccnt           ,reccnt           ,long    ,5      ;
        통신매체코드                         ,tongsingb        ,tongsingb        ,char    ,2      ;
        레코드갯수1			                 ,reccnt1          ,reccnt1          ,long    ,5	  ;
    end
    t5011InBlock1,기본입력1,input,occurs;
    begin
        계좌번호                             ,accno            ,accno            ,char    ,20     ;
        입력비밀번호                         ,passwd           ,passwd           ,char    ,8      ;
        선물옵션종목번호                     ,expcode          ,expcode          ,char    ,32     ;
        dummy원주문번호			             ,dummyorgordno	   ,dummyorgordno	 ,long    ,3      ;
        원주문번호                           ,orgordno         ,orgordno         ,long    ,7      ;
        취소수량                             ,qty              ,qty              ,long    ,16     ;
    end
    t5011OutBlock,기본출력,output;
    begin
        레코드갯수                           ,reccnt           ,reccnt           ,long    ,5      ;
        통신매체코드                         ,tongsingb        ,tongsingb        ,char    ,2      ;
    end
    t5011OutBlock1,기본출력1,output,occurs;
    begin
        계좌번호                             ,accno            ,accno            ,char    ,20     ;
        입력비밀번호                         ,passwd           ,passwd           ,char    ,8      ;
        선물옵션종목번호                     ,expcode          ,expcode          ,char    ,32     ;
        dummy원주문번호			             ,dummyorgordno	   ,dummyorgordno	 ,long    ,3      ;
        원주문번호                           ,orgordno         ,orgordno         ,long    ,7      ;
        취소수량                             ,qty              ,qty              ,long    ,16     ;
    end
    t5011OutBlock2,기본출력2,output,occurs;
    begin
        dummy주문번호                        ,dummyordno       ,dummyordno       ,long    ,3      ;
        주문번호                             ,ordno            ,ordno            ,long    ,7      ;
        메시지코드                           ,msgcode          ,msgcode          ,char    ,4      ;
        메시지내용                           ,msg              ,msg              ,char    ,100    ;
        처리시각                             ,proctime         ,proctime         ,char    ,9      ;
	end
    END_DATA_MAP
END_FUNCTION_MAP
