import { Post } from '../post/post'
export interface FThread {
  Id: number
  ForumID: number
  Name: string
  Text: string
  Sticky: boolean
  Active: boolean
  DateCreated: Date
  StartedByUserId: number
  Locked: boolean
  Posts: Post[]
}
