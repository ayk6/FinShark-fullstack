import React from 'react'
import { CommentGet } from '../../../Models/Comment'
import StocCommentListItem from './StockCommentListItem/StocCommentListItem'

type Props = { comments: CommentGet[] }

const StockCommentList = ({ comments }: Props) => {
  return (
    <>
      {comments ? comments.map((comment) => {
        return <StocCommentListItem comment={comment} />;
      }) : ""}
    </>
  )
}

export default StockCommentList