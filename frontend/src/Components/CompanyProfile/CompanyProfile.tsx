import React from 'react'
import StockComment from '../StockComment/StockComment'

type Props = {}

const CompanyProfile = (props: Props) => {
    return (
        <>
            <div>Company Profile</div>
            <StockComment stockSymbol="" />
        </>
    )
}

export default CompanyProfile