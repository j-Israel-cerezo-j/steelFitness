class CustomDate extends Date {
    constructor(date){
        // if( typeof(date) === "string" ){
        //     super
        // }
        if( date === undefined )
            super();
        else
            super(date);
    }

    static fromLocale(strDate){
        if( typeof(strDate) !== "string" ){
            throw "the argument must be string";
        }
        let date = new CustomDate(strDate);
        let offset = date.getTimezoneOffset();
        date.setMinutes( date.getMinutes() + offset);
        return date;
    }

    addMonth(months){
        this.setMonth(this.getMonth() + months);
        return this;
    }
    subMonth(months){
        this.setMonth(this.getMonth() - months);
        return this;
    }
    addDay(days) {
        this.setDate(this.getDate() + days);
        return this;
    }
    subDay(days) {
        this.setDate(this.getDate() - days);
        return this;
    }

    toIsoLocaleDateString(){
        let dateTokens = this.toLocaleDateString().split('/');

        let day = dateTokens[0];
        if( day.length<2 ){
            day = '0' + day;
        }
        let month = dateTokens[1];
        if( month.length<2 ){
            month = '0' + month;
        }

        return dateTokens[2] + '-' + month + '-' + day;
    }
    addhour(hour) {
        this.setHours(this.getHours() + hour);
        return this;
    }
}
